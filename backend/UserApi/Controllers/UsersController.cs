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
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await this._userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        public async Task<IActionResult> SaveUser([FromBody] UserDto user)
        {
            var userResult = await this._userService.AddUser(user);

            if (userResult.Success)
                return Ok(userResult.Data);

            return BadRequest(userResult.Errors);
        }



        [HttpPut("{userId}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(List<string>))]
        public async Task<IActionResult> Update([FromRoute] int userId,  [FromBody] UserDto user)
        {
            if (userId != user.Id)
                return BadRequest("Id usuário inválido");

            var userResult = await this._userService.UpdateUser(user);

            if (userResult.Success)
                return Ok(userResult.Data);

            return BadRequest(userResult.Errors);
        }
    }
}