using System.Text.RegularExpressions;
using System.Text.Json;
using server.src.Application.DTOs.User;
using server.src.Utilities;
using server.src.Domain.Exceptions;

namespace server.src.Application.DTOs.Validators;

public static class UserRequestValidator
{
    private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

    public static void ValidateCreateUser(UserRequest userRequest)
    {
        if (string.IsNullOrWhiteSpace(userRequest.Username) ||
            string.IsNullOrWhiteSpace(userRequest.Email) ||
            string.IsNullOrWhiteSpace(userRequest.Password) ||
            !Regex.IsMatch(userRequest.Email, EmailPattern))
        {
            var expectedRequest = new UserRequest
            {
                Username = "NotNullOrWhiteSpace",
                Email = "NotNullOrWhiteSpace@domain.com",
                Password = "NotNullOrWhiteSpace"
            };

            throw new InvalidUserRequestException(expectedRequest, userRequest);
        }
    }

    public static void ValidateLoginUser(UserRequest userRequest)
    {
        if (string.IsNullOrWhiteSpace(userRequest.Email) ||
            string.IsNullOrWhiteSpace(userRequest.Password) ||
            !Regex.IsMatch(userRequest.Email, EmailPattern))
        {
            var expectedRequest = new UserRequest
            {
                Email = "NotNullOrWhiteSpace@domain.com",
                Password = "NotNullOrWhiteSpace"
            };

            throw new InvalidUserRequestException(expectedRequest, userRequest);
        }
    }

    public static void DisplayErrorMessage(UserRequest expectedRequest, UserRequest actualRequest)
    {
        Console.WriteLine("Invalid request format.\n");

        Console.WriteLine("Expected format:");
        TerminalColor.SetOutputColor(ConsoleColor.Green);
        Console.WriteLine(JsonSerializer.Serialize(expectedRequest, new JsonSerializerOptions { WriteIndented = true }));
        TerminalColor.ResetOutputColor();

        Console.WriteLine("\nReceived format:");
        TerminalColor.SetOutputColor(ConsoleColor.Green);
        Console.WriteLine(JsonSerializer.Serialize(actualRequest, new JsonSerializerOptions { WriteIndented = true }));
        TerminalColor.ResetOutputColor();
    }
}
