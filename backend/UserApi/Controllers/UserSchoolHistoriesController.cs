using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Users.Domain.Dtos;
using Users.Domain.Interfaces.Services;

namespace UserApi.Controllers
{
    [Route("api/users/{userId}/schoolhistories/{schollHistoryId}")]
    [ApiController]
    public class UserSchoolHistoriesController : ControllerBase
    {
        private readonly ISchoolHistoryService _schoolHistoryService;
        public UserSchoolHistoriesController(ISchoolHistoryService schoolHistoryService)
        {
            this._schoolHistoryService = schoolHistoryService;
        }


        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(ResultDto<SchoolHistoryDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound, Type = typeof(List<string>))]
        public async Task<IActionResult> GetUserSchoolHistory([FromRoute] int userId, [FromRoute] int schollHistoryId)
        {
            var result = await this._schoolHistoryService.GetByAsync(userId, schollHistoryId);

            if (result.Success)
                return Ok(result.Data);

            return NotFound(result.Errors);
        }
    }
}
