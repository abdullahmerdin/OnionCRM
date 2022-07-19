using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;


namespace OnionCRM.Infrastructure.MiddleLayers.Exceptions;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Serilog.ILogger _logger;
    public ExceptionHandlerMiddleware(RequestDelegate next, Serilog.ILogger logger)
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
            _logger.Information("@{MethodName} - {Message}", nameof(ex), "Information");
            _logger.Error("@{MethodName} - {Message}", nameof(ex), "Error");
            _logger.Fatal("@{MethodName} - {Message}", nameof(ex), "Fatal");
            _logger.Warning("@{MethodName} - {Message}", nameof(ex), "Warning");
            _logger.Debug("@{MethodName} - {Message}", nameof(ex), "Debug");
            throw;
        }
    }

        
}