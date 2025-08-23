using System.ComponentModel.DataAnnotations;

namespace MZWalks.UI.Models.DTOs;

public class RegionDto
{
    [MaxLength(26)] public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string RegionImageURL { get; set; }
}