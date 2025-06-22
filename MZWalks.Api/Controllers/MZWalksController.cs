using Microsoft.AspNetCore.Mvc;

namespace MZWalks.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MZWalksController : ControllerBase
{
    // GET
    [HttpGet()]
    public IActionResult Get()
    {
        return Ok();
    }
}