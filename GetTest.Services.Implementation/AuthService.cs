using GetTest.Contracts;
using GetTest.Contracts.Response;
using GetTest.Services.Enum;
using GetTest.Services.Implementation.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GetTest.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly GetTestDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthService(GetTestDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<ApiResponse> Authentication(Auth auth)
        {
            var authUser = await _dbContext.Users.Where(u => u.Mobile == auth.Mobile && u.Password == auth.Password).SingleOrDefaultAsync();
            return authUser != null
                    ? new ApiResponse { Token = GetToken(authUser),  Message = "Success", StatusCode = StatusCode.Ok }
                    : new ApiResponse { Token = null, Message = "Success", StatusCode = StatusCode.NotFound };
        }

        public string GetToken(Entities.User user)
        {
            if (user == null)
            {
                return null;
            }

            var signingKey = Convert.FromBase64String(_configuration["Jwt:SigningSecret"]);
            var expiryDuration = int.Parse(_configuration["Jwt:ExpiryDuration"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("userid", user.UserID.ToString()),
                        new Claim("role", user.Role)
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return token;
        }
    }
}
