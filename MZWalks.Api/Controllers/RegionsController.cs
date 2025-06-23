using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Data;
using MZWalks.Api.Mapping;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Controllers;

[ApiController]
public class RegionsController(Database database) : ControllerBase
{
    [HttpGet(ApiEndpoints.Regions.GetAll)]
    public ActionResult GetAll()
    {
        var regions = database.Regions.ToList();
        var response = regions.Select((region) => region.MapToResponse());
        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Regions.Get)]
    public ActionResult Get([FromRoute] Guid id)
    {
        var region = database.Regions.Find(id);
        if (region is null) return NotFound();
        var response = region.MapToResponse();
        return Ok(response);
    }

    [HttpPost(ApiEndpoints.Regions.Create)]
    public ActionResult Create([FromBody] CreateRegionRequest request)
    {
        if (request is null) return BadRequest();
        var region = request.MapToRegion();
        database.Regions.Add(region);
        database.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = region.Id }, region.MapToResponse());
    }
}