using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.Entities;
using blog_dotnet_api.Properties.Src.Servicios.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace blog_dotnet_api.Properties.Src.Servicios.Implements
{
    public class TokenService(UserManager<User> userManager, IConfiguration configuration) : ITokenService
    {
        private readonly UserManager<User> _userManager = userManager;

        private readonly IConfiguration _conf = configuration;

        
        public string GenerateTokenAsync(User user){
            
            var tokenKey = _conf.GetSection("AppSettings:Token").Value!;
            
            if(user.Email is null  || tokenKey is null){
                throw new Exception("Error al generar el token.");
            }

            var claims = new List<Claim>{
                new ("Id", user.Id.ToString()),
                new ("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}