using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Contracts.Response;

public class WalkResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double LengthInKm { get; set; }

    public string? WalkImageURl { get; set; }
    // public Guid DifficultyId { get; set; }
    // public Guid RegionId { get; set; }

    // nav props
    // Include the data in the response
    public Difficulty? Difficulty { get; set; }
    public RegionResponse? Region { get; set; }
}