using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Data;
using MZWalks.Api.Mapping;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Controllers;

[ApiController]
public class WalksController(Database database) : ControllerBase
{
    // GET
    [HttpGet(ApiEndpoints.Walks.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var walks = await database.Walks.ToListAsync();
        var response = walks.Select((walk) => walk.MapToResponse());
        return Ok(response);
    }

    // Get by id
    [HttpGet(ApiEndpoints.Walks.Get)]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var walk = await database.Walks.FindAsync(id);
        if (walk is null) return NotFound();
        var response = walk.MapToResponse();
        return Ok(response);
    }

    [HttpPost(ApiEndpoints.Walks.Create)]
    public async Task<IActionResult> Create([FromBody] CreateWalkRequest request)
    {
        if (request is null) return BadRequest();
        var walk = request.MapToWalk();
        await database.Walks.AddAsync(walk);
        await database.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = walk.Id }, walk.MapToResponse());
    }
}