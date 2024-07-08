using ClaimsAPI.Models;
using ClaimsAPI.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClaimsAPI.Service.LoginService;
using ClaimsAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ClaimsAPI.Service.LoginService;

namespace ClaimsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        
        private IConfiguration _configuration;
        private readonly ILoginService _LoginService;
        public LoginController(IConfiguration config, ILoginService loginService)
        {
            _LoginService = loginService;
            _configuration = config;
        }
     



        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult>Login(string username, string password)
        {
            var TemplateService = _LoginService.Login(username, password, _configuration);
            if (TemplateService == null)
            {
                return NotFound();
            }
            return Ok(TemplateService);
        }
       

      

        }


    }
