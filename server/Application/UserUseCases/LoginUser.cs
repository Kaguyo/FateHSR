using server.Domain.Entities;

namespace server.Application.UserUseCases;

public class LoginUser
{
    private readonly IUserRepository _repository;

    public LoginUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public User Execute(string email, string password)
    {
        var user = _repository.GetByEmailInMemory(email);
        return user;
    }
}
