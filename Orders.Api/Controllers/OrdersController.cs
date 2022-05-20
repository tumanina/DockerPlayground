using Microsoft.AspNetCore.Mvc;
using Orders.Api.Clients;
using Orders.Api.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICatalogClient _catalog;

        public OrdersController(IOrdersRepository ordersRepository, ICatalogClient catalog)
        {
            _ordersRepository = ordersRepository;
            _catalog = catalog;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _ordersRepository.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _catalog.GetBrandsAsync();
            return Ok(brands.Select(b => new Brand { Id = b.Id, Name = b.Name }));
        }
    }
}
