using System.ComponentModel.DataAnnotations;

namespace MZWalks.UI.Models.DTOs;

public class CreateRegionDto
{
    public required string Code { get; set; }
    public required string Name { get; set; }
    public string RegionImageURL { get; set; }
}