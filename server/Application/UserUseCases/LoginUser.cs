using server.Domain.Entities;

namespace server.Application.UserUseCases;

public class LoginUser
{
    private readonly IUserRepository _repository;

    public LoginUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task Execute(string email, string password)
    {
        return _repository.Login(email, password);
    }
}
