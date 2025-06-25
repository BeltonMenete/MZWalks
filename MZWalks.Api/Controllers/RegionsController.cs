using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Data;
using MZWalks.Api.Mapping;
using MZWalks.Api.Models.Domain;
using MZWalks.Api.Repositories;

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
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var region = await regionRepository.GetById(id);
        if (region is null) return NotFound();
        var response = region.MapToResponse();
        return Ok(response);
    }

    [HttpPost(ApiEndpoints.Regions.Create)]
    public async Task<IActionResult> Create([FromBody] CreateRegionRequest request)
    {
        var region = request.MapToRegion();
        await regionRepository.CreateAsync(region);
        return CreatedAtAction(nameof(Get), new { id = region.Id }, region.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Regions.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequest request)
    {
        var region = await regionRepository.GetById(id);
        if (region is null) return NotFound();
        region.MapUpdate(request);
        await regionRepository.UpdateAsync(region);
        return Ok(region.MapToResponse());
    }

    [HttpDelete(ApiEndpoints.Regions.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var region = await regionRepository.GetById(id);
        if (region is null) return NotFound();
        await regionRepository.DeleteAsync(region);
        return NoContent();
    }
}