using server.src.Domain.Entities;
using server.src.Domain.Interfaces;

namespace server.src.Application.UserUseCases;

public class CreateUserTest(IUserRepository repository) : ICreateUser
{
    private readonly IUserRepository _repository = repository;

    public Task<User> Execute(string username, string email, string password)
    {
        var user = new User
        {
            Id = 0,
            Username = username,
            Email = email,
            PasswordHash = password.GetHashCode().ToString()
        };

        Console.Clear();
        _repository.AddInMemory(user);
        return Task.FromResult(user);
    }
}
