using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Orders.Tests.IntegrationTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Orders.Tests.IntegrationTests
{
    [TestClass]
    public class OrdersApiTests
    {
        private readonly string _url;

        public OrdersApiTests()
        {
            _url = Environment.GetEnvironmentVariable("OrdersApiUrl") ?? "http://localhost:8093/api";
        }

        [TestMethod]
        public async Task GetOrders_OneOrders_ReturnsCorrectResponse()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{_url}/orders");
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<IEnumerable<Order>>(content);

                    Assert.AreEqual(result.Count(), 1);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }
    }
}