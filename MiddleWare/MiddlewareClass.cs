

using WebProject.Models;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Extensions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebProject.Models;
using WebProject.Models;

namespace WebProject.Middleware
{
    public class MiddlewareClass
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareClass> _logger;
        private static IConfiguration _config;
        public MiddlewareClass(RequestDelegate next, ILogger<MiddlewareClass> logger, IConfiguration config)

        {
            _next = next;
            _logger = logger;
            _config = config;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);
            var handler = new JwtSecurityTokenHandler();
            var b = context.Request.Headers["Authorization"].ToString();
            var tokenSecure = handler.ReadToken(context.Request.Headers["Authorization"]) as SecurityToken;
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(context.Request.Headers["Authorization"], validations, out tokenSecure);
            var prinicpal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            //if (prinicpal is ClaimsPrincipal claim) ;

            User user = new User();

            int a;
            int.TryParse(claims.Claims.FirstOrDefault(x => x.Type == "Id")?.Value ?? "", out a);
            user.Id = a;
            Role role;
            Enum.TryParse(claims.Claims.FirstOrDefault(x => x.Type == "Role")?.Value ?? "", out role);
            user.Role = role;


            // Store user object in context.Items
            context.Items["User"] = user;
            
            await _next(context);

        }

    }
}
