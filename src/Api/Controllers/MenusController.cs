using Contracts.Menus;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("hosts")]
public class MenusController : ApiController
{
    [HttpPost]
    [Route("{hostId}/menus")]
    public IActionResult CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        return Ok(request);
    }
}