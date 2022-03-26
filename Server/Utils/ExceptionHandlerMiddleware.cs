using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            } catch (DbUpdateException e) {
                await HandleException(httpContext, HttpStatusCode.Conflict, e);
            } catch (TimestampFormatException e) {
                await HandleException(httpContext, HttpStatusCode.UnprocessableEntity, e);
            }
        }

        async Task HandleException(HttpContext httpContext, HttpStatusCode code, Exception exception)
        {
            var message = exception.Message;
            while (exception.InnerException != null) {
                message += Environment.NewLine + exception.InnerException.Message;
                exception = exception.InnerException;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;
            await httpContext.Response.WriteAsync(message);
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
