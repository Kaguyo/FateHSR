using Microsoft.AspNetCore.Mvc;
using server.src.API.DTOs.User;
using server.src.API.DTOs.Handlers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using server.src.Domain.Exceptions;

namespace server.src.API.Controllers;

public class UserController : ControllerBase
{
    public static void LoadControllers(WebApplication app)
    {
        // app.MapGet("/verify", (HttpContext context, IConfiguration config) =>
        // {
        //     var token = context.Request.Query["token"].ToString();

        //     if (string.IsNullOrEmpty(token))
        //         return Results.BadRequest(new { Message = "Token não fornecido." });

        //     var jwtSecret = config.GetSection("JwtSettings:Secret").Value;

        //     if (string.IsNullOrEmpty(jwtSecret))
        //         return Results.Problem("JwtSecret não configurado corretamente.");

        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var key = Encoding.ASCII.GetBytes(jwtSecret);

        //     try
        //     {
        //         tokenHandler.ValidateToken(token, new TokenValidationParameters
        //         {
        //             ValidateIssuer = false,
        //             ValidateAudience = false,
        //             ValidateLifetime = true,
        //             ValidateIssuerSigningKey = true,
        //             IssuerSigningKey = new SymmetricSecurityKey(key),
        //             ClockSkew = TimeSpan.Zero
        //         }, out SecurityToken validatedToken);

        //         var jwtToken = (JwtSecurityToken)validatedToken;
        //         var email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        //         if (string.IsNullOrEmpty(email))
        //             return Results.BadRequest(new { Message = "E-mail não encontrado no token." });

        //         Console.WriteLine(email, "\n", token);
        //         // Aqui você pode marcar o e-mail como verificado, ou permitir o acesso

        //         return Results.Ok(new { Message = "Token válido!", Email = email });
        //     }
        //     catch (SecurityTokenExpiredException)
        //     {
        //         Console.WriteLine("Token expirado.");
        //         return Results.StatusCode(401);
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("Erro ao validar token: " + ex);
        //         return Results.StatusCode(401);
        //     }
        // });

        app.MapPost("/users", (IEmailService emailService, ICreateUser createUserUseCase, [FromBody]UserRequestDTO userRequestDTO) =>
        {
            try
            {
                Console.WriteLine($"Received request: {userRequestDTO.Email}");
                UserRequestHandler.ValidateCreateUser(userRequestDTO);
                emailService.SendEmailWithToken(userRequestDTO.Email);
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
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}\n{ex}");
                return Results.StatusCode(400);
            }
        });

        app.MapPost("/auth/login", async (ILoginUser loginUseCase, UserRequestDTO userRequestDTO) =>
        {
            try
            {
                UserRequestHandler.ValidateLoginUser(userRequestDTO);
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