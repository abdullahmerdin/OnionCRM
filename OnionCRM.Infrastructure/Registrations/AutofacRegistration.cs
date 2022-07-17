using Autofac;
using OnionCRM.Application.Interfaces.IPhoneNumberServices;
using OnionCRM.Application.Services.PhoneNumberServices;


namespace OnionCRM.Infrastructure.Registrations;

public class AutofacRegistration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PhoneNumberService>().As<IPhoneNumberService>().SingleInstance();

    }
}