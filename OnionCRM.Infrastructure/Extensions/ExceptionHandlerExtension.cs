using Microsoft.AspNetCore.Builder;
using OnionCRM.Infrastructure.MiddleLayers.Exceptions;

namespace OnionCRM.Infrastructure.Extensions;

public static class ExceptionHandlerExtension
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}