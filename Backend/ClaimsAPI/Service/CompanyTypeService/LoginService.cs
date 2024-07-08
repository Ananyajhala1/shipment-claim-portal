using ClaimsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using ClaimsAPI.Models.Entites;
using ClaimsAPI.Models.ViewModels;
using System.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

//

using Microsoft.AspNetCore.Authorization;



namespace ClaimsAPI.Service.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ShipmentClaimsContext shipmentClaimsContext;
        public LoginService(ShipmentClaimsContext shipmentClaimsContext)
        {
            this.shipmentClaimsContext = shipmentClaimsContext;
        }
        public async Task<AuthDTO> Login(string username, string password,IConfiguration config)
        {
            // Find the user by username and password hash (insecure example, use hashed passwords in production)
            var user = await shipmentClaimsContext.UserCredentials
                .Include(x => x.User)
               .ThenInclude(x => x.Company)
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);


            if (user != null)
            {
                var token = Genrate(user,config);
                AuthDTO authdto = new AuthDTO();
                authdto.AuthToken = token;
                authdto.RefreshToken = null;
                authdto.FirstName = user.User.FirstName;
                authdto.IsLogin = true;
                authdto.CompanyId = user.User.CompanyId;
                authdto.CompanyName = user.User.Company.CompanyName;


                return authdto;

            }

            else
            {
                AuthDTO authdto = new AuthDTO();
                authdto.IsLogin = false;


                throw new Exception($"auth failed");

            }

        }
        private string Genrate(UserCredential user, IConfiguration config)
        {
           var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.UserName)

            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
