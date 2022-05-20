using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Users.Data.Configuration;

namespace Orders.Api.Clients
{
    public class CatalogClient: ICatalogClient
    {
        private readonly string _url;

        public CatalogClient(IOptions<CatalogConfiguration> configuration)
        {
            _url = configuration.Value?.Url;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{_url}/brands");
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<Brand>>(content);
                }
            }

            return new List<Brand>();
        }
    }
}
