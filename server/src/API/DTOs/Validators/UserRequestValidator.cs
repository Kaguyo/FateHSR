using System.Text.RegularExpressions;
using System.Text.Json;
using server.src.API.DTOs.User;
using server.src.Utilities;
using server.src.Domain.Exceptions;

namespace server.src.API.DTOs.Validators;

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
        if (Persistence.Repositories.UserRepository.GetByEmailInMemory(userRequest.Email) != null)
        {
            throw new AlreadyInUseException();
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
}