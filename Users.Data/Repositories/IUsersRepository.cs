using System.Collections.Generic;

namespace Users.Data.Repositories
{
    public interface IUsersRepository
    {
        void AddUserAsync(User user);
        IEnumerable<User> GetUsers();
    }
}
