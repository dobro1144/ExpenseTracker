using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using UseCases.Exceptions;

namespace Server.Utils
{
    public class ExceptionHandlerMiddleware
    {
        readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try {
                await _next(httpContext);
            } catch (EntityNotFoundException e) {
                await HandleException(httpContext, HttpStatusCode.NotFound, e);
            }
        }

        async Task HandleException(HttpContext httpContext, HttpStatusCode code, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;
            await httpContext.Response.WriteAsync(exception.Message);
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
