using System.Net;


namespace MZWalks.Api.Middlewares;

public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger = logger;
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var errorId = Guid.CreateVersion7();
            // log the exception
            _logger.LogError(ex, $"{errorId} --- {ex.Message}");

            // Return Custom response Error
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var error = new
            {
                Id = errorId,
                ErrorMessage = "Something went wrong! The team is working to solve it ASAP"
            };

            await context.Response.WriteAsJsonAsync(error);
        }
    }
}