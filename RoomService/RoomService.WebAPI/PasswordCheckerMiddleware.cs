using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;

namespace RoomService.WebAPI
{
    public class PasswordCheckerMiddleware
    {
       
        public PasswordCheckerMiddleware(RequestDelegate next)
        {
            _next = next;


        }

        public async Task InvokeAsync(HttpContext context)
        
        {
            if (context.Request.Headers.TryGetValue("passwordKey", out var apiKeyValue))
            {
                if (apiKeyValue == "passwordKey123456789")
                {
                    await _next(context);
                    return;
                }
            }

            context.Response.StatusCode = 403; // Forbidden
        }

        public static class MiddlewareExtensions
        {
            public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<PasswordCheckerMiddleware>();
            }
        }
    }
}

