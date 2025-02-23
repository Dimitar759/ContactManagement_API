using DataAccess;
using Helpers;
using Mapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
DependencyInjectionHelper.InjectDbContext(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

// Register services and repositories
DependencyInjectionHelper.InjectServices(builder.Services);
DependencyInjectionHelper.InjectRepositories(builder.Services);

// Add services to the container.

builder.Services.AddControllers();

// Register AutoMapper with the MappingProfile class
builder.Services.AddAutoMapper(typeof(MappingProfile));


// Configure Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
