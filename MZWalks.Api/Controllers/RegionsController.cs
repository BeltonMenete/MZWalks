﻿using ByteAether.Ulid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;
using MZWalks.Api.Validators;
using Microsoft.AspNetCore.OpenApi;
using MZWalks.Api.Contracts.Response;

namespace MZWalks.Api.Controllers;

[ApiController]
[Tags("Regions")]
public class RegionsController(IRegionRepository regionRepository) : ControllerBase
{
    [Authorize(Roles = "Reader")]
    [HttpGet(ApiEndpoints.Regions.GetAll)]
    [ProducesResponseType(typeof(IEnumerable<RegionResponse>), StatusCodes.Status200OK)]
    [EndpointSummary("Retrieves all regions.")]
    public async Task<IActionResult> GetAll()
    {
        var regions = await regionRepository.GetAllAsync();
        var response = regions.Select((region) => region.MapToResponse());
        return Ok(response);
    }

    [Authorize(Roles = "Reader")]
    [HttpGet(ApiEndpoints.Regions.Get)]
    [ProducesResponseType(typeof(RegionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [EndpointSummary("Retrieves a region by ID.")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var region = await regionRepository.GetById(id);
        if (region is null) return NotFound();
        var response = region.MapToResponse();
        return Ok(response);
    }
    [Authorize(Roles = "Reader")]
    [HttpPost(ApiEndpoints.Regions.Create)]
    [ValidateModel]
    [ProducesResponseType(typeof(RegionResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Creates a new region.")]
    public async Task<IActionResult> Create([FromBody] CreateRegionRequest request)
    {
        var region = request.MapToRegion();
        await regionRepository.CreateAsync(region);
        return CreatedAtAction(nameof(Get), new { id = region.Id }, region.MapToResponse());
    }

    [ValidateModel]
    [Authorize(Roles = "Reader")]
    [HttpPut(ApiEndpoints.Regions.Update)]
    [ProducesResponseType(typeof(RegionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Updates an existing region.")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateRegionRequest request)
    {
        var region = await regionRepository.GetById(id);
        if (region is null) return NotFound();
        region.MapUpdate(request);
        await regionRepository.UpdateAsync(region);
        return Ok(region.MapToResponse());
    }

    [Authorize(Roles = "Writer")]
    [HttpDelete(ApiEndpoints.Regions.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Deletes a region by ID.")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var region = await regionRepository.GetById(id);
        if (region is null) return NotFound();
        await regionRepository.DeleteAsync(region);
        return NoContent();
    }
}