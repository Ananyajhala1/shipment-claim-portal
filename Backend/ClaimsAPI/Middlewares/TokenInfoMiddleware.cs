using ClaimsAPI.Models;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace ClaimsAPI.Middlewares
{
    public class TokenInfoMiddleware : ITokenInfo
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TokenInfoMiddleware> _logger;

        public TokenInfoMiddleware(RequestDelegate next, ILogger<TokenInfoMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, RequestTokenInfo requestTokenInfo)
        {
            if (context.Request.Path.StartsWithSegments("/api/login", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            var authorizationHeader = context.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                _logger.LogWarning("Authorization header missing or invalid.");
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization header missing or invalid.");
                return;
            }

            var token = authorizationHeader.Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken? jsonToken;

            try
            {
                jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                if (jsonToken == null)
                {
                    throw new ArgumentException("Invalid JWT token");
                }
                _logger.LogInformation("JWT token successfully read.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Invalid JWT token: {ex.Message}");
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid JWT token.");
                return;
            }

            var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "userId");
            var clientIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "clientId");
            var clientNameClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "clientName");
            var userNameClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "UserName");

            if (userIdClaim == null || clientIdClaim == null || clientNameClaim == null || userNameClaim == null)
            {
                _logger.LogWarning("Required claims missing in token.");
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Required claims missing in token.");
                return;
            }

            requestTokenInfo.userId = userIdClaim.Value;
            requestTokenInfo.clientId = clientIdClaim.Value;
            requestTokenInfo.clientName = clientNameClaim.Value;
            requestTokenInfo.userName = userNameClaim.Value;

            _logger.LogInformation($"Token validated. UserId: {requestTokenInfo.userId}, ClientId: {requestTokenInfo.clientId}");
            await _next(context);
        }
    }
}
