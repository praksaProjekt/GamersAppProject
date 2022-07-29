using System.Text.Json;

namespace GamersApp.Middleware;
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (AppException error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new { message = error?.Message, StatusCode = error.StatusCode });
            await response.WriteAsync(result);
        }
    }
}

public class AppException : Exception
{
    public int StatusCode { get; }

    public AppException(string message, int code) : base(message) 
    {
        StatusCode = code;
    }
}