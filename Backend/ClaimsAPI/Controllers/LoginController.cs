using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ClaimsAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ShipmentClaimsContext _dbContext;
        private IConfiguration _configuration;
        public LoginController(ShipmentClaimsContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _configuration = config;
        }


       
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult>Login(string username, string password)
        {
            // Find the user by username and password hash (insecure example, use hashed passwords in production)
            var user = await _dbContext.UserCredentials
                .Include(x => x.User)
               .ThenInclude(x => x.Company)
                .FirstOrDefaultAsync(u => u.UserName==username && u.Password == password);


            if (user != null)
            {
                var token = Genrate(user);
                AuthDTO authdto = new AuthDTO();
                authdto.AuthToken = token;
                authdto.RefreshToken = null;
                authdto.FirstName = user.User.FirstName;
                authdto.IsLogin = true;
                authdto.CompanyId = user.User.CompanyId;
                authdto.CompanyName = user.User.Company.CompanyName;


                return Ok(authdto);
                
            }

            else
            {
                AuthDTO authdto = new AuthDTO();
                authdto.IsLogin = false;
               

                return BadRequest(authdto);

            }

          }

        private string Genrate(UserCredential user)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.UserName)

            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        }


    }
