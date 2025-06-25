using System.ComponentModel.DataAnnotations;

namespace MZWalks.Api.Contracts.Requests;

public class UpdateWalkRequest
{
    [MaxLength(100, ErrorMessage = "Should be maximum 100 characters")]
    public required string Name { get; set; }

    [MaxLength(1000, ErrorMessage = "Should be maximum 1000 characters")]
    public required string Description { get; set; }

    [Range(0, 50)] public required double LengthInKm { get; set; }
    public string WalkImageURl { get; set; }
    public required Guid DifficultyId { get; set; }
    public required Guid RegionId { get; set; }
}