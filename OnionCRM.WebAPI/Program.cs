using Microsoft.EntityFrameworkCore;
using OnionCRM.Infrastructure.Registrations;
using OnionCRM.Persistance.Context;
using Swashbuckle.Swagger;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Database and Context
builder.Services.AddDbContext<OnionProjectContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("API"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();