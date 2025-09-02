namespace server.src.Application.UserUseCases;

public class LoginUser
{
    private readonly IUserRepository _repository;

    public LoginUser(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task Execute(string email, string password)
    {
        return _repository.LoginInMemory(email, password);
    }
}
