using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> Update(UpdateRegionDto region)
    {
        var response = await _regionService.UpdateRegionAsync(region);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var response = await _regionService.DeleteRegionAsync(id);
        return RedirectToAction("Index");
    }
}