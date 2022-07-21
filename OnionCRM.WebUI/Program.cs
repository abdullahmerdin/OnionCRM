using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using OnionCRM.Application.Interfaces.IAppUserServices;
using OnionCRM.Application.Services.AppUserServices;
using OnionCRM.Infrastructure.Extensions;
using OnionCRM.Persistance.Context;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using OnionCRM.Core.Domain;
using OnionCRM.Infrastructure.MiddleLayers;


var builder = WebApplication.CreateBuilder(args);


//Add Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new OnionCRM.Infrastructure.Registrations.AutofacRegistration());
  
    });

////To Find Razor Pages in Areas
//builder.Services.Configure<RazorViewEngineOptions>(options =>
//{
//    options.ViewLocationExpanders.Add(new ViewLocationExpander());
//});

//Add Serilog
Log.Logger = new LoggerConfiguration().CreateLogger();
builder.Host.UseSerilog(((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
    .WriteTo.Console()));

//Add Authorization
builder.Services.AddControllersWithViews(c =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    c.Filters.Add(new AuthorizeFilter(policy));

    
});

//Add DbContext
builder.Services.AddDbContext<OnionProjectContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

builder.Services.AddDbContext<IdentityDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Identity"));
});
builder.Services.AddDbContext<LogDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Log"));
});

//Add Default Identity
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //ExceptionHandle extension method
    app.UseExceptionHandlerMiddleware();
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();