using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;
using MZWalks.Api.Validators;


namespace MZWalks.Api.Controllers;

[ApiController]
public class WalksController(IWalkRepository walkRepository) : ControllerBase
{
    // GET
    [HttpGet(ApiEndpoints.Walks.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
    {
        var walks = await walkRepository.GetAllAsync(filterOn, filterQuery);
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
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] CreateWalkRequest request)
    {
        var walk = request.MapToWalk();
        var result = await walkRepository.CreateAsync(walk);
        if (result is not null)
            return BadRequest(result);

        return CreatedAtAction(nameof(Get), new { id = walk.Id }, walk.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Walks.Update)]
    [ValidateModel]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequest request)
    {
        var walk = await walkRepository.GetById(id);
        if (walk is null) return NotFound("Walk Not Found");
        walk.MapUpdate(request);
        var result = await walkRepository.UpdateAsync(walk);
        if (result is not null) return BadRequest(result);
        return Ok(walk.MapToResponse());
    }

    [HttpDelete(ApiEndpoints.Walks.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var walk = await walkRepository.GetById(id);
        if (walk is null) return NotFound();
        await walkRepository.DeleteAsync(walk);
        return NoContent();
    }
}