using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace GamersApp.Middleware
{
    public static class GlobalErrorMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var body = context.Response.Body;
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Error = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }

    internal class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Error { get; set; }
    }
}