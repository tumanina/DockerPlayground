using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Users.Data.Configuration;

namespace Users.Data.Context
{
    public class UsersContext : IUsersContext
    {
        public UsersContext(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            Users = database.GetCollection<User>(settings.Value.CollectionName);
        }

        public IMongoCollection<User> Users { get; }
    }
}
