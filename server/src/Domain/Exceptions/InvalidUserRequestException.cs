using server.src.API.DTOs.User;
using server.src.Utilities;
using System.Text.Json;
namespace server.src.Domain.Exceptions;

public class InvalidUserRequestException(UserRequestDTO expected, UserRequestDTO actual) : Exception("Invalid user request.")
{
    public UserRequestDTO Expected { get; } = expected;
    public UserRequestDTO Actual { get; } = actual;
    public static void DisplayErrorMessage(UserRequestDTO expectedRequest, UserRequestDTO actualRequest)
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