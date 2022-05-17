using Microsoft.AspNetCore.Mvc;

namespace Orders.Api.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        [Route("/check")]
        public IActionResult Check()
        {
            return Ok("Works!");
        }
    }
}
