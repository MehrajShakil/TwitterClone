using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly List<User> _users = new List<User>();

        public User AddUser(User user)
        {
            _users.Add(user);

            return user;
        }

        public User UpdateUser(User user)
        {
            _users.RemoveAll(u => u.Id == user.Id);
            _users.Add(user);
            return user;
        }

        public bool DeleteUser(User user)
        {
            return _users.Remove(user);
        }

        public User? GetUserById(Guid id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public List<User> GetUsers()
        {
            return _users.ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u =>
                string.Equals(u.Email, email.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }
}
