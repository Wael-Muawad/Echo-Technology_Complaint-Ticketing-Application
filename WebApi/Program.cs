using Domain.Entities;
using Persistence.utils;
using Application.Utils;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Utils;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerConfigurations();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.RegisterInfraStructure(builder.Configuration);
builder.Services.RegisterApplecation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGroup("/Identity").MapIdentityApi<AppUser>();
//app.MapIdentityApi<AppUser>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
