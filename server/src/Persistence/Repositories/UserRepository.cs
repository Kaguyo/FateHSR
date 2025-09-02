using server.src.Domain.Entities;

namespace server.src.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public Task AddInMemory(User user)
        {
            _users.Add(user);
            foreach (User usuario in _users)
            {
                Console.WriteLine(usuario);
            }
            return Task.CompletedTask;
        }
        public Task<User> LoginInMemory(string email, string password)
        {
            var user = GetByEmailInMemory(email);
            if (user?.PasswordHash == password.GetHashCode().ToString())
            {
                return Task.FromResult(user);
            }

            throw new ArgumentException("Invalid email or password.");
        }
        private static User? GetByEmailInMemory(string email)
        {
            return _users.FirstOrDefault(user => user.Email == email);
        }
    }
}