using server.src.Domain.Entities;

public interface IUserRepository
{
    Task Add(User user);
    Task<User> Login(string email, string password); 
}

