using server.src.Domain.Entities;

namespace server.src.Application.UserUseCases;

public class CreateUser
{
    private readonly IUserRepository _repository;

    public CreateUser(IUserRepository repository)
    {
        _repository = repository;
    }

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
        _repository.Add(user);
        return Task.FromResult(user);
    }
}
