using Microsoft.AspNetCore.Mvc;
using Users.Api.Models;
using Users.Api.Services;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_usersService.GetUsers());
        }

        [HttpPost]
        public IActionResult Create(CreateUserModel user)
        {
            _usersService.CreateUser(user);

            return Ok();
        }
    }
}
