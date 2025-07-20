using ByteAether.Ulid;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Contracts.Response;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;
using MZWalks.Api.Validators;

namespace MZWalks.Api.Controllers;

[ApiController]
[Tags("Walks")]
public class WalksController(IWalkRepository walkRepository) : ControllerBase
{
    [HttpGet(ApiEndpoints.Walks.GetAll)]
    [ProducesResponseType(typeof(IEnumerable<WalkResponse>), StatusCodes.Status200OK)]
    [EndpointSummary("Retrieves all walks with optional filtering, sorting, and pagination.")]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? filterOn,
        [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy,
        [FromQuery] bool? isAscending,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 1000)
    {
        var walks = await walkRepository.GetAllAsync(
            filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

        var response = walks.Select(w => w.MapToResponse());
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Walks.GetSummary)]
    [ProducesResponseType(typeof(IEnumerable<WalkSummaryResponse>), StatusCodes.Status200OK)]
    [EndpointSummary("Returns a summarized list of walks.")]
    public async Task<IActionResult> GetSummary(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 1000)
    {
        var walks = await walkRepository.GetAllAsync(pageNumber: pageNumber, pageSize: pageSize);
        var summary = walks.MapToList();
        return Ok(summary);
    }

    [HttpGet(ApiEndpoints.Walks.Get)]
    [ProducesResponseType(typeof(WalkResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Retrieves a walk by ID.")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var walk = await walkRepository.GetById(id);
        if (walk is null) return NotFound();
        return Ok(walk.MapToResponse());
    }

    [HttpPost(ApiEndpoints.Walks.Create)]
    [ValidateModel]
    [ProducesResponseType(typeof(WalkResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Creates a new walk.")]
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
    [ProducesResponseType(typeof(WalkResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Updates an existing walk.")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateWalkRequest request)
    {
        var walk = await walkRepository.GetById(id);
        if (walk is null) return NotFound("Walk Not Found");

        walk.MapUpdate(request);
        var result = await walkRepository.UpdateAsync(walk);
        if (result is not null) return BadRequest(result);

        return Ok(walk.MapToResponse());
    }

    [HttpDelete(ApiEndpoints.Walks.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Deletes a walk by ID.")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var walk = await walkRepository.GetById(id);
        if (walk is null) return NotFound();

        await walkRepository.DeleteAsync(walk);
        return NoContent();
    }
}