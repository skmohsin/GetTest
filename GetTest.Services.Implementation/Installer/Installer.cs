using Autofac;
using AutoMapper;
using GetTest.Services.Implementation.Mappings;

namespace GetTest.Services.Implementation.Installer
{
    public class Installer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Register(ctx => Mapping.GetMapper())
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
