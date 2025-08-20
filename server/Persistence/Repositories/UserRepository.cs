using server.Domain.Entities;

namespace server.Persistence.Repositories;

public class UserRepository
{
    internal static readonly List<User> _users = new();

    public Task AddUserInMemory(User user)
    {
        _users.Add(user);
        foreach (User usuario in _users)
        {
            Console.WriteLine(usuario);
        }
        return Task.CompletedTask;
    }

    public User? GetByEmailInMemory(string email)
    {
        return _users.FirstOrDefault(user => user.Email == email);
    }
}
