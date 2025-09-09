using server.src.API.Controllers;
using server.src.Persistence.Repositories;
using server.src.Application.UserUseCases;
using server.src.Domain.Interfaces;
using server.src.Domain.Entities;

namespace server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddScoped<ICreateUser, CreateUserTest>();
            builder.Services.AddScoped<ILoginUser, LoginUserTest>();
        }   
        else
        {
            builder.Services.AddScoped<ICreateUser, CreateUserTest>(); // Replace with real implementation later
            builder.Services.AddScoped<ILoginUser, LoginUserTest>(); // Replace with real implementation later
        }
        var e = new EmailSettings();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                builder => builder
                    .WithOrigins("http://localhost:5173")
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        var app = builder.Build();

        UserController.LoadControllers(app);

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("AllowFrontend");
        //app.UseAuthorization(); 

        app.Run(); 
    }
}
