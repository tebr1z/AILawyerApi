using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HuquqApi.Middleware
{
    public class RateLimitRedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RateLimitRedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

           
            if (context.Response.StatusCode == 429)
            {
                context.Response.Clear(); 
                context.Response.StatusCode = 302; 
                context.Response.Headers["Location"] = "https://google.com"; 
            }
        }
    }
}
