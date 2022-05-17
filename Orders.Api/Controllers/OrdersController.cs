using Microsoft.AspNetCore.Mvc;
using Orders.Api.Data;
using System.Threading.Tasks;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brands = await _ordersRepository.GetAllAsync();
            return Ok(brands);
        }
    }
}
