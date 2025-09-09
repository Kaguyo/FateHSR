using server.src.Domain.Entities;

public interface ILoginUser
{
    Task<User?> Execute(string email, string password);
}