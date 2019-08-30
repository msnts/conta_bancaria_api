using ContaBancaria.API.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ContaBancaria.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}