using ClaimsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ClaimsAPI.Service.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ShipmentClaimsContext _shipmentClaimsContext;

        public LoginService(ShipmentClaimsContext shipmentClaimsContext)
        {
            _shipmentClaimsContext = shipmentClaimsContext;
        }

        public async Task<AuthDTO> Login(string username, string password, IConfiguration config)
        {
            var user = await _shipmentClaimsContext.UserCredentials
                .Include(x => x.User)
                .ThenInclude(x => x.Company)
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                var token = GenerateToken(user, config);

              
                var userId = GetUserIdFromToken(token);
         
                AuthDTO authDto = new AuthDTO
                {
                  

                    
                    userId = GetUserIdFromToken(token),

                    AuthToken = token,
                    RefreshToken = null,
                    FirstName = user.User.FirstName,
                    IsLogin = true,
                    CompanyId = user.User.CompanyId,
                    CompanyName = user.User.Company.CompanyName
                };

                return authDto;
            }
            else
            {
                AuthDTO authDto = new AuthDTO
                {
                    IsLogin = false
                };

                throw new Exception("auth failed");
            }
        }

        private string GenerateToken(UserCredential user, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new System.Security.Claims.Claim("userName",user.User.FirstName.ToString()),
                new System.Security.Claims.Claim("userId", user.User.UserId.ToString()),
                new System.Security.Claims.Claim("clientId",user.User.CompanyId.ToString()),
                new System.Security.Claims.Claim("clientName",user.User.Company.CompanyName.ToString())

                };

            JwtSecurityToken token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetUserIdFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken == null)
            {
                throw new ArgumentException("Invalid JWT token");
            }

            var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "userId");

            if (userIdClaim == null)
            {
                throw new ArgumentException("UserId claim not found in token");
            }

            return userIdClaim.Value;
        }
    }
}
