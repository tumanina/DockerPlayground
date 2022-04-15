using MongoDB.Driver;

namespace Users.Data.Context
{
    public interface IUsersContext
    {
        IMongoCollection<User> Users { get; }
    }
}
