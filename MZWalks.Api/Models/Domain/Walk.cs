using System.ComponentModel.DataAnnotations;

namespace MZWalks.Api.Models.Domain;

public class Walk
{
    [MaxLength(26)]
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required double LengthInKm { get; set; }
    public required string WalkImageURl { get; set; }
    public string DifficultyId { get; set; }
    public string RegionId { get; set; }

    // Navigation properties
    public Difficulty? Difficulty { get; set; }
    public Region? Region { get; set; }
}