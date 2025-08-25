using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Console;
using MZWalks.UI.Models.DTOs;

namespace MZWalks.UI.Controllers;

public class RegionsController : Controller
{
    private readonly RegionService _regionService;

    public RegionsController(RegionService regionService)
    {
        _regionService = regionService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var regions = await _regionService.GetRegionsAsync();
        return View(regions);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRegionDto region)
    {
        var response = await _regionService.CreateRegionsAsync(region);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Update(string id)
    {
        var regionDto = await _regionService.GetRegionAsync(id);
        
        return View(regionDto);
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(RegionDto region)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var updateRegion = new UpdateRegionDto()
        {
            Code = region.Code,
            Name = region.Name,
            RegionImageURL = region.RegionImageURL
        };
        var response = await _regionService.UpdateRegionAsync(region.Id, updateRegion);
        Console.WriteLine(response.IsSuccessful);
        Console.WriteLine(response.Content);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _regionService.DeleteRegionAsync(id);
        return RedirectToAction("Index");
    }
}