using Microsoft.AspNetCore.Mvc;

namespace MZWalks.Api.Controllers;

[ApiController]
public class DifficultiesController() : ControllerBase
{
    // GET
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}