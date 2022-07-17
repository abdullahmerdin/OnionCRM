using Microsoft.AspNetCore.Http;


namespace OnionCRM.Infrastructure.MiddleLayers.Exceptions;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (Exception ex)
        {
            Serilog.Log.Error(ex, "ExceptionHandlerMiddleware");
        }
    }

        
}