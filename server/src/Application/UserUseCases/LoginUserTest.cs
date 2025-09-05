namespace server.src.Application.UserUseCases;
using server.src.Domain.Entities;
using server.src.Domain.Interfaces;

public class LoginUserTest(IUserRepository repository): ILoginUser
{
    private readonly IUserRepository _repository = repository;

    public Task<User?> Execute(string email, string password)
    {
        return _repository.LoginInMemory(email, password);
    }
}
