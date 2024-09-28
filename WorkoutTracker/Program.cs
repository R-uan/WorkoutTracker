using FluentValidation;
using WorkoutTracker.Database;
using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Application.Models;
using WorkoutTracker.Application.Services;
using WorkoutTracker.Application.Interfaces;
using WorkoutTracker.Application.Repositories;
using WorkoutTracker.Application.Utilities.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(db => db.UseNpgsql(builder.Configuration.GetConnectionString("MainDb")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IValidator<UserModel>, UserModelValidator>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x => {
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
        ValidateIssuer = true,
        
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
