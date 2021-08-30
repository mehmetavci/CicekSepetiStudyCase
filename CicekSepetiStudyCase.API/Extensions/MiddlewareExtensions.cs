using CicekSepetiStudyCase.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace CicekSepetiStudyCase.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();

            return app;
        }
    }
}
