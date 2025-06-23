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
        var region = request.MapToRegion();
        database.Regions.Add(region);
        database.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = region.Id }, region.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Regions.Update)]
    public ActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequest request)
    {
        var region = database.Regions.Find(id);
        if (region is null) return NotFound();
        region.MapToRegion(request);
        database.Regions.Update(region);
        database.SaveChanges();
        return NoContent();
    }

    [HttpDelete(ApiEndpoints.Regions.Delete)]
    public ActionResult Delete([FromRoute] Guid id)
    {
        var region = database.Regions.Find(id);
        if (region is null) return NotFound();
        database.Regions.Remove(region);
        database.SaveChanges();
        return NoContent();
    }
}