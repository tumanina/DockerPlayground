using System.Collections.Generic;
using Users.Api.Models;

namespace Users.Api.Services
{
    public interface IUsersService
    {
        void CreateUser(CreateUserModel user);
        IEnumerable<UserModel> GetUsers();
    }
}
