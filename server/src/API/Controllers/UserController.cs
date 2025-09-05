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
        app.MapPost("/users", (ICreateUser createUserUseCase, UserRequestDTO userRequestDTO) =>
        {
            try
            {
                UserRequestValidator.ValidateCreateUser(userRequestDTO);
                var createdUser = createUserUseCase.Execute(userRequestDTO.Username, userRequestDTO.Email, userRequestDTO.Password);
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

        app.MapPost("/auth/login", async (ILoginUser loginUseCase, UserRequestDTO userRequestDTO) =>
        {
            try
            {
                UserRequestValidator.ValidateLoginUser(userRequestDTO);
                var authenticatedUser = await loginUseCase.Execute(userRequestDTO.Email, userRequestDTO.Password);
                if (authenticatedUser == null)
                {
                    return Results.Json(new { message = "Credenciais invalidas. Verifique seu email e senha." }, statusCode: 401);
                }

                return Results.Ok(new { message = "Login bem-sucedido", user = authenticatedUser });
            }
            catch (InvalidUserRequestException ex)
            {   
                Console.Clear();
                Console.WriteLine($"Erro: {ex.Message}");
                InvalidUserRequestException.DisplayErrorMessage(ex.Expected, ex.Actual);
                
                return Results.BadRequest(new { ex.Message });
            }
        });
    }
}