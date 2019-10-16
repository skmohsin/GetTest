using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using GetTest.Services.Implementation.DataBaseContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Microsoft.IdentityModel.Tokens;
using SwaggerOptions = GetTest.Utilities.Extension.SwaggerOptions;
using GetTest.Api.Filter;

namespace GetTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //Mvc and Model Filters
            services.AddMvc(options => options.Filters.Add(typeof(ValidateModelFilter))).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Connection String
            var ConnectionString = Configuration.GetConnectionString("Local");
            services.AddDbContext<GetTestDbContext>(options => options.UseSqlServer(ConnectionString));

            //Jwt 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
             {
                 var signingKey = Convert.FromBase64String(Configuration["Jwt:SigningSecret"]);
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(signingKey)
                 };
             });

            //Swagger
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Info { Title = "Get Test Api", Version = "V1" }));

        }

        // Autofac module registration
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var assemblies = Directory.GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                            .Select(Assembly.LoadFrom).ToArray();

            builder.RegisterAssemblyModules(assemblies);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Swagger Configuration
            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndPoint, swaggerOptions.Description);
            });

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
