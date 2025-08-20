using server.Domain.Entities;

namespace server.Application.UserUseCases;

public class LoginUserUseCaseInMemory
{
    private readonly List<User> _users;

    public LoginUserUseCaseInMemory(List<User> users)
    {
        _users = users;
    }

    public User Execute(string email, string password)
    {
        var user = _users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password.GetHashCode().ToString());
        return user;
    }
}
