using Catalog.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandsRepository _brandsRepository;
        public BrandController(IBrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brands = await _brandsRepository.GetAllAsync();
            return Ok(brands);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Brand brand)
        {
            await _brandsRepository.AddBrandAsync(brand);

            return Ok();
        }
    }
}
