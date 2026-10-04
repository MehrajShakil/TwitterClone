using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(User user);
        User? GetUserById(Guid id);
        List<User> GetUsers();
        User? GetUserByEmail(string email);
    }
}
