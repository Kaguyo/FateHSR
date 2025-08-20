using server.Domain.Entities;

namespace server.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public Task Add(User user)
        {
            _users.Add(user);
            foreach (User usuario in _users)
            {
                Console.WriteLine(usuario);
            }
            return Task.CompletedTask;
        }

        public User? GetByEmailInMemory(string email)
        {
            return _users.FirstOrDefault(user => user.Email == email);
        }
    }
}