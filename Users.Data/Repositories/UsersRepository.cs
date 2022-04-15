using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Users.Data.Context;

namespace Users.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IUsersContext _context;

        public UsersRepository(IUsersContext context)
        {
            _context = context;
        }

        public void AddUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            _context.Users.InsertOne(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Find(_ => true).ToList();
        }
    }
}
