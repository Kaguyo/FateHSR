using server.src.Domain.Entities;

namespace server.src.Domain.Interfaces;
public interface IUserRepository
{
    Task AddInMemory(User user);
    Task<User?> LoginInMemory(string email, string password);
}

