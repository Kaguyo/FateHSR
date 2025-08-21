using server.src.Application.DTOs.User;

namespace server.src.Domain.Exceptions;

public class InvalidUserRequestException(UserRequest expected, UserRequest actual) : Exception("Invalid user request.")
{
    public UserRequest Expected { get; } = expected;
    public UserRequest Actual { get; } = actual;
}
