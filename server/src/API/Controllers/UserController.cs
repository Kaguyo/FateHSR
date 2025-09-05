using Microsoft.AspNetCore.Mvc;
using server.src.API.DTOs.User;
using server.src.API.DTOs.Validators;
using server.src.Application.UserUseCases;
using server.src.Domain.Exceptions;

namespace server.src.API.Controllers;

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
            catch (InvalidUserRequestException ex)
            {
                Console.Clear();
                Console.WriteLine($"Erro: {ex.Message}");
                InvalidUserRequestException.DisplayErrorMessage(ex.Expected, ex.Actual);
                
                return Results.BadRequest(new { ex.Message });
            }
            catch (AlreadyInUseException ex)
            {   
                Console.Clear();
                Console.WriteLine($"Erro: {ex.Message}");
                return Results.Conflict(new { ex.Message });
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
            catch (InvalidUserRequestException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                InvalidUserRequestException.DisplayErrorMessage(ex.Expected, ex.Actual);
                
                return Results.BadRequest(new { ex.Message });
            }
        });
    }
}