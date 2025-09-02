using server.src.Domain.Entities;

public interface IUserRepository
{
    Task AddInMemory(User user);
    Task<User> LoginInMemory(string email, string password); 
}

