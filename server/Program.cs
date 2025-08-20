using server.API.Controllers;
using server.Domain.Entities;
using server.Persistence.Repositories;
using server.Application.UserUseCases;

namespace server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<CreateUser>();
        builder.Services.AddScoped<LoginUser>();

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
