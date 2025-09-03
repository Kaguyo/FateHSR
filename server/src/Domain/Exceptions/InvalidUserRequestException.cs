using server.src.Application.DTOs.User;
using server.src.Utilities;
using System.Text.Json;
namespace server.src.Domain.Exceptions;

public class InvalidUserRequestException(UserRequest expected, UserRequest actual) : Exception("Invalid user request.")
{
    public UserRequest Expected { get; } = expected;
    public UserRequest Actual { get; } = actual;

    public static void DisplayErrorMessage(UserRequest expectedRequest, UserRequest actualRequest)
    {   
        Console.WriteLine("Expected format:");
        TerminalColor.SetOutputColor(ConsoleColor.Green);
        Console.WriteLine(JsonSerializer.Serialize(expectedRequest, new JsonSerializerOptions { WriteIndented = true }));
        TerminalColor.ResetOutputColor();

        Console.WriteLine("\nReceived format:");
        TerminalColor.SetOutputColor(ConsoleColor.Red);
        Console.WriteLine(JsonSerializer.Serialize(actualRequest, new JsonSerializerOptions { WriteIndented = true }));
        TerminalColor.ResetOutputColor();
    }
}