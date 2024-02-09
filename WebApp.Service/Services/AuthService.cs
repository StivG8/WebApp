using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.IRepositories;
using WebApp.Domain.Entities.Users;
using WebApp.Service.Exceptions;
using WebApp.Service.Extensions;
using WebApp.Service.Interfaces;

namespace WebApp.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> userRepository;
        private readonly IConfiguration configuration;
        public AuthService(IGenericRepository<User> userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }
        public async ValueTask<string> GenerateToken(string email, string password)
        {
            User user = await userRepository.GetAsync(u =>
                u.Email == email && u.Password.Equals(password));
            
            if (user is null)
                throw new WebAppSystemException(400, "Email or Password is incorrect");

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            expires: DateTime.Now.AddMonths(int.Parse(configuration["Jwt:Lifetime"])),
            claims: new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            },
            signingCredentials: new SigningCredentials(
                key: authSigningKey,
                algorithm: SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
