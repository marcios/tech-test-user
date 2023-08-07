using Microsoft.AspNetCore.Mvc;
using Users.Domain.Entities;
using Users.Domain.Interfaces.Services;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScholaritiesController : ControllerBase
    {
        private readonly IScholarityService _scholarityService;
        public ScholaritiesController(IScholarityService scholarityService = null)
        {
            this._scholarityService = scholarityService;
        }


        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<Scholarity>))]
        public async Task<IActionResult> GetAllScholarities()
        {
            var scholarities = await this._scholarityService.GetAllAsync();
            return Ok(scholarities);
        }
    }
}
