using ByteAether.Ulid;
using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;
using MZWalks.Api.Validators;


namespace MZWalks.Api.Controllers;

[ApiController]
public class RegionsController(IRegionRepository regionRepository) : ControllerBase
{
    [HttpGet(ApiEndpoints.Regions.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var regions = await regionRepository.GetAllAsync();
        var response = regions.Select((region) => region.MapToResponse());
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Regions.Get)]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var region = await regionRepository.GetById(Ulid.Parse(id).ToGuid());
        if (region is null) return NotFound();
        var response = region.MapToResponse();
        return Ok(response);
    }

    [HttpPost(ApiEndpoints.Regions.Create)]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] CreateRegionRequest request)
    {
        var region = request.MapToRegion();
        await regionRepository.CreateAsync(region);
        return CreatedAtAction(nameof(Get), new { id = region.Id }, region.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Regions.Update)]
    [ValidateModel]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateRegionRequest request)
    {
        var region = await regionRepository.GetById(Ulid.Parse(id).ToGuid());
        if (region is null) return NotFound();
        region.MapUpdate(request);
        await regionRepository.UpdateAsync(region);
        return Ok(region.MapToResponse());
    }

    [HttpDelete(ApiEndpoints.Regions.Delete)]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var region = await regionRepository.GetById(Ulid.Parse(id).ToGuid());
        if (region is null) return NotFound();
        await regionRepository.DeleteAsync(region);
        return NoContent();
    }
}