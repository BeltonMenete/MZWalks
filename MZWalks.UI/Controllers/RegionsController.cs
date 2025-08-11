using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace MZWalks.UI.Controllers;

public class RegionsController : Controller
{
    private readonly RegionService _regionService;

    public RegionsController(RegionService regionService)
    {
        _regionService = regionService;
    }

    public async Task<IActionResult> Index()
    {
        var regions = await _regionService.GetRegionsAsync();
        return View(regions);
    }
}