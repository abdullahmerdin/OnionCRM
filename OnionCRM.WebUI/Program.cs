using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using OnionCRM.Application.Interfaces.IAppUserServices;
using OnionCRM.Application.Services.AppUserServices;
using OnionCRM.Infrastructure.Extensions;
using OnionCRM.Persistance.Context;
using Serilog;
using OnionCRM.Core.Domain;


var builder = WebApplication.CreateBuilder(args);

//Add Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new OnionCRM.Infrastructure.Registrations.AutofacRegistration());
  
    });

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
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>();



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