using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class DinnersController : ApiController
    {
        [HttpGet]
        [Authorize]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}