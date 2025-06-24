namespace MZWalks.Api.Contracts.Requests;

public class UpdateWalkRequest
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public double LengthInKm { get; set; }
    public string WalkImageURl { get; set; }
    public required Guid DifficultyId { get; set; }
    public required Guid RegionId { get; set; }
}