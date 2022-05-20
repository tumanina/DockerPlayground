using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Api.Clients
{
    public interface ICatalogClient
    {
        public Task<IEnumerable<Brand>> GetBrandsAsync();
    }
}
