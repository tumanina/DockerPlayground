using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Brand> brands)
        {
            bool existBrand = brands.Find(p => true).Any();
            if (!existBrand)
            {
                brands.InsertManyAsync(GetBrands());
            }
        }

        private static IEnumerable<Brand> GetBrands()
        {
            return new List<Brand>()
            {
                new Brand()
                {
                    Id = Guid.NewGuid(),
                    Name = "test brand 1"
                }
            };
        }
    }
}
