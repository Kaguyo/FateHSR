using System.Text.RegularExpressions;
using System.Text.Json;
using server.src.API.DTOs.User;
using server.src.Utilities;
using server.src.Domain.Exceptions;

namespace server.src.API.DTOs.User;

public class UserRequestHandler
{
    private const string EmailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

    public static void ValidateCreateUser(UserRequestDTO userRequestDTO)
    {
        if (string.IsNullOrWhiteSpace(userRequestDTO.Username) ||
            string.IsNullOrWhiteSpace(userRequestDTO.Email) ||
            string.IsNullOrWhiteSpace(userRequestDTO.Password) ||
            !Regex.IsMatch(userRequestDTO.Email, EmailPattern))
        {
            var expectedRequest = new UserRequestDTO
            {
                Username = "NotNullOrWhiteSpace",
                Email = "NotNullOrWhiteSpace@domain.com",
                Password = "NotNullOrWhiteSpace"
            };

            throw new InvalidUserRequestException(expectedRequest, userRequestDTO);
        }
        if (Persistence.Repositories.UserRepository.GetByEmailInMemory(userRequestDTO.Email) != null)
        {
            throw new AlreadyInUseException();
        }
    }

    public static void ValidateLoginUser(UserRequestDTO userRequestDTO)
    {
        if (string.IsNullOrWhiteSpace(userRequestDTO.Email) ||
            string.IsNullOrWhiteSpace(userRequestDTO.Password) ||
            !Regex.IsMatch(userRequestDTO.Email, EmailPattern))
        {
            var expectedRequest = new UserRequestDTO
            {
                Email = "NotNullOrWhiteSpace@domain.com",
                Password = "NotNullOrWhiteSpace"
            };

            throw new InvalidUserRequestException(expectedRequest, userRequestDTO);
        }
    }
}