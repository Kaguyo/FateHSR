using server.Domain.Entities;

namespace server.Application.UserUseCases;

public class CreateUserUseCaseInMemory
{
    private readonly IUserRepository _users;

    public Task<User> Execute(string username, string email, string password)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = username,
            Email = email,
            PasswordHash = password.GetHashCode().ToString()
        };

        _users.Add(user);
        return Task.FromResult(user);
    }
}
