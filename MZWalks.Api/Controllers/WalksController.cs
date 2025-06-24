using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Data;
using MZWalks.Api.Mapping;
using MZWalks.Api.Models.Domain;
using MZWalks.Api.Repositories;

namespace MZWalks.Api.Controllers;

[ApiController]
public class WalksController(IWalkRepository walkRepository) : ControllerBase
{
    // GET
    [HttpGet(ApiEndpoints.Walks.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var walks = await walkRepository.GetAllAsync();
        var response = walks.Select((walk) => walk.MapToResponse());
        return Ok(response);
    }

    // Get by id
    [HttpGet(ApiEndpoints.Walks.Get)]
    public async Task<ActionResult> Get([FromRoute] Guid id)
    {
        var walk = await walkRepository.GetById(id);
        if (walk is null) return NotFound();
        var response = walk.MapToResponse();
        return Ok(response);
    }

    [HttpPost(ApiEndpoints.Walks.Create)]
    public async Task<IActionResult> Create([FromBody] CreateWalkRequest request)
    {
        var walk = request.MapToWalk();
        var result = await walkRepository.CreateAsync(walk);
        if (result is not null)
            return BadRequest(result);
        
        return CreatedAtAction(nameof(Get), new { id = walk.Id }, walk.MapToResponse());
    }
}