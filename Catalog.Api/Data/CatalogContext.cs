using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Brands = database.GetCollection<Brand>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Brands);
        }

        public IMongoCollection<Brand> Brands { get; }
    }

    public interface ICatalogContext
    {
        IMongoCollection<Brand> Brands { get; }
    }
}
