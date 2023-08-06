using Microsoft.AspNetCore.Mvc;
using Users.Domain.Dtos;
using Users.Domain.Interfaces.Services;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        

        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            this._userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(statusCode:StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await this._userService.GetAllAsync();
            return Ok(users);
        }
    }
}