using System.Text.RegularExpressions;
using System.Text.Json;
using server.src.Application.DTOs.User;

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

            throw new ArgumentException(BuildErrorMessage(expectedRequest, userRequest));
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

            throw new ArgumentException(BuildErrorMessage(expectedRequest, userRequest));
        }
    }

    private static string BuildErrorMessage(UserRequest expectedRequest, UserRequest actualRequest)
    {
        return $"Invalid request format.\n\nExpected format:\n{JsonSerializer.Serialize(expectedRequest)}\n\nReceived format:\n{JsonSerializer.Serialize(actualRequest)}";
    }
}
