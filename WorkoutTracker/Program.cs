using FluentValidation;
using WorkoutTracker.Database;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Application.Services;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Repositories;
using WorkoutTracker.Application.Utilities.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(db => db.UseNpgsql(builder.Configuration.GetConnectionString("MainDb")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IValidator<UserModel>, UserModelValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
