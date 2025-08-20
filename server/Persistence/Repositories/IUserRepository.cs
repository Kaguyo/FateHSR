namespace server.Domain.Entities
{
    public interface IUserRepository
    {
        Task Add(User user);
        User? GetByEmailInMemory(string email);
    }
}
