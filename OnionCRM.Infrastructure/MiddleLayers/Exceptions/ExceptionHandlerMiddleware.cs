using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;


namespace OnionCRM.Infrastructure.MiddleLayers.Exceptions;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred: {ExceptionMessage}", ex.Message);
            _logger.LogInformation(ex, "An unhandled exception has occurred: {ExceptionMessage}", ex.Message);
            _logger.LogWarning(ex, "An unhandled exception has occurred: {ExceptionMessage}", ex.Message);
            _logger.LogDebug(ex, "An unhandled exception has occurred: {ExceptionMessage}", ex.Message);
            _logger.LogTrace(ex, "An unhandled exception has occurred: {ExceptionMessage}", ex.Message);
            _logger.LogCritical(ex, "An unhandled exception has occurred: {ExceptionMessage}", ex.Message);
            throw;
        }
    }

        
}