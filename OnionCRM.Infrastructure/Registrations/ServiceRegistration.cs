using Microsoft.Extensions.DependencyInjection;
using OnionCRM.Application.Interfaces.IAppUserServices;
using OnionCRM.Application.Interfaces.IPhoneNumberServices;
using OnionCRM.Application.Interfaces.IRoleServices;
using OnionCRM.Application.Services.AppUserServices;
using OnionCRM.Application.Services.PhoneNumberServices;
using OnionCRM.Application.Services.RoleServices;

namespace OnionCRM.Infrastructure.Registrations;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IPhoneNumberService, PhoneNumberService>();
        services.AddScoped<IAppUserService, AppUserService>();
        services.AddScoped<IRoleService, RoleService>();


    }
    


}