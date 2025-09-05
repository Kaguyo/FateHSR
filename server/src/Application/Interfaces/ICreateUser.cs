using server.src.Domain.Entities;

public interface ICreateUser
{
    Task<User> Execute(string username, string email, string password);

}