namespace MZWalks.Api.Models.Domain;

public class Walk
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required double LengthInKm { get; set; }
    public required string WalkImageURl { get; set; }
    public byte[] DifficultyId { get; set; }
    public Guid RegionId { get; set; }

    // Navigation properties
    public Difficulty? Difficulty { get; set; }
    public Region? Region { get; set; }
}