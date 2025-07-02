namespace MZWalks.Api.Models.Domain;

public class Walk
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required double LengthInKm { get; set; }
    public required string WalkImageURl { get; set; }
    public Guid DifficultyId { get; set; }
    public Guid RegionId { get; set; }

    // Navigation properties
    public Difficulty? Difficulty { get; set; }
    public Region? Region { get; set; }
}