global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using SuperHeroApi.Repository;
global using SuperHeroApi.Interfaces;
global using SuperHeroApi.Models;
global using SuperHeroApi.Data;
global using SuperHeroApi.Dto;
global using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IDisguiseRepository, DisguiseRepository>();
builder.Services.AddScoped<IPowerRepository, PowerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
