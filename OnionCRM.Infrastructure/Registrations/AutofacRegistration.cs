using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnionCRM.Application.Interfaces.IAppUserServices;
using OnionCRM.Application.Interfaces.IPhoneNumberServices;
using OnionCRM.Application.Interfaces.IRoleServices;
using OnionCRM.Application.Services.AppUserServices;
using OnionCRM.Application.Services.PhoneNumberServices;
using OnionCRM.Application.Services.RoleServices;
using OnionCRM.Core.Domain;


namespace OnionCRM.Infrastructure.Registrations;

public class AutofacRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PhoneNumberService>().As<IPhoneNumberService>().SingleInstance();
        
        builder.RegisterType<AppUserService>().As<IAppUserService>().SingleInstance();
        builder.RegisterType<UserManager<AppUser>>().PropertiesAutowired();

        builder.RegisterType<RoleService>().As<IRoleService>().SingleInstance();
    }
}