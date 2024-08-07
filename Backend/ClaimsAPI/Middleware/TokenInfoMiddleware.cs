using ClaimsAPI.Models;
using Microsoft.AspNetCore.HttpOverrides;
using System.IdentityModel.Tokens.Jwt;

namespace ClaimsAPI.Middleware
{
    public class TokenInfoMiddleware : ITokenInfo
    {


        private readonly RequestDelegate _next;
        private readonly RequestTokenInfo _requestTokenInfo;

        public TokenInfoMiddleware(RequestDelegate next, RequestTokenInfo requestTokenInfo)
        {
            _next = next;
            _requestTokenInfo = requestTokenInfo;
        }



        public async Task Invoke(HttpContext context)




        {

            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken == null)
            {
                throw new ArgumentException("Invalid JWT token");
            }

            var userIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "userId");
            var clientIdClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "clientId");
            var clientNameClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "clientName");
            var userNameClaim = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "UserName");



            if (userIdClaim == null)
            {
                throw new ArgumentException("UserId claim not found in token");
            }

          _requestTokenInfo.userId = userIdClaim.Value;
            _requestTokenInfo.clientId = clientIdClaim.Value;
            _requestTokenInfo.clientName = clientNameClaim.Value;
            _requestTokenInfo.userName = userNameClaim.Value;

          


            await _next(context);
        }







    }
}
