using Catalog.Api.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IOptions<DatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            Brands = database.GetCollection<Brand>(databaseSettings.Value.CollectionName);
            CatalogContextSeed.SeedData(Brands);
        }

        public IMongoCollection<Brand> Brands { get; }
    }

    public interface ICatalogContext
    {
        IMongoCollection<Brand> Brands { get; }
    }
}
