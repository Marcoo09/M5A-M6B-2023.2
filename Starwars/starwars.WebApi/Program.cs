using System.Collections.Immutable;
using System;
using starwars.Domain;
using starwars.ServicesFactory;
using starwars.WebApi.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddScoped<AuthenticationFilter>();

var servicesFactory = new ServicesFactory();
servicesFactory.RegistrateServices(builder.Services);

// Inside ConfigureServices method
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Your API",
        Version = "v1",
        Description = "Your API description here" // Add an overall API description
    });

    // Use data annotations to provide descriptions for endpoints
    c.OperationFilter<SwaggerOperationDescriptionFilter>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();

