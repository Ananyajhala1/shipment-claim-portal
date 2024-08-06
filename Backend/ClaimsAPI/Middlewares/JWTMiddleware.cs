using ClaimsAPI.Service;
using ClaimsAPI.Service.UserInfoService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;
    private readonly IUserInfoService _userInfoService;
    private readonly ILogger<JwtMiddleware> _logger;

    public JwtMiddleware(RequestDelegate next, IConfiguration config, IUserInfoService userInfoService, ILogger<JwtMiddleware> logger)
    {
        _next = next;
        _config = config;
        _userInfoService = userInfoService;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            await AttachUserToContext(context, token);
        }

        await _next(context);
    }

    private async Task AttachUserToContext(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _config["Jwt:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            var userIdClaim = principal.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;

            if (userIdClaim != null && int.TryParse(userIdClaim, out int userId))
            {
                var user = await _userInfoService.UserDetails(userId); 
                if (user != null)
                {
                    context.Items["User"] = user;
                    context.Items["CompanyId"] = user.CompanyId; 
                }
            }
            else
            {
                _logger.LogWarning("Invalid UserId claim in JWT.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "JWT validation failed.");
            
        }
    }
}
