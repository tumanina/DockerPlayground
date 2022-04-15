using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Data
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly ICatalogContext _context;

        public BrandsRepository(ICatalogContext context)
        {
            _context = context;
        }

        public async Task AddBrandAsync(Brand brand)
        {
            brand.Id = Guid.NewGuid();
            await _context.Brands.InsertOneAsync(brand);
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands.Find(_ => true).ToListAsync();
        }
    }

    public interface IBrandsRepository
    {
        Task<List<Brand>> GetAllAsync();
        Task AddBrandAsync(Brand brand);
    }
}
