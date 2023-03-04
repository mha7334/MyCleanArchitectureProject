using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DinnersController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
