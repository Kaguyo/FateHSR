using Microsoft.AspNetCore.Mvc;
using server.Application.DTOs.User;
using server.Application.UserUseCases;

namespace server.API.Controllers;

public class UserController : ControllerBase
{
    public static void LoadControllers(WebApplication app)
    {
        app.MapPost("/users", (CreateUser createUserUseCase, UserRequest userRequest) =>
        {
            try
            {
                UserRequestValidator.ValidateCreateUser(userRequest);
                var createdUser = createUserUseCase.Execute(userRequest.Username, userRequest.Email, userRequest.Password);
                return Results.Created($"/users", createdUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                // Console.ReadKey(true);
                return Results.BadRequest(new { ex.Message });
            }
        });

        app.MapPost("/auth/login", (LoginUser loginUseCase, UserRequest userRequest) =>
        {
            try
            {
                UserRequestValidator.ValidateLoginUser(userRequest);
                var authenticatedUser = loginUseCase.Execute(userRequest.Email, userRequest.Password);
                if (authenticatedUser == null)
                {
                    return Results.Json(new { message = "Credenciais invalidas. Verifique seu email e senha." }, statusCode: 401);
                }

                return Results.Ok(new { message = "Login bem-sucedido", user = authenticatedUser });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                // Console.ReadKey(true);
                return Results.BadRequest(new { ex.Message });
            }
        });
    }
}