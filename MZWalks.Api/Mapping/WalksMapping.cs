using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Contracts.Response;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Mapping;

public static class WalksMapping
{
    public static Walk MapToWalk(this CreateWalkRequest request)
    {
        return new Walk()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            LengthInKm = request.LengthInKm,
            WalkImageURl = request.WalkImageURl,
            DifficultyId = request.DifficultyId,
            RegionId = request.RegionId 
        };
    }

    public static WalkResponse MapToResponse(this Walk walk)
    {
        return new WalkResponse()
        {
            Id = walk.Id,
            Name = walk.Name,
            Description = walk.Description,
            LengthInKm = walk.LengthInKm,
            WalkImageURl = walk.WalkImageURl,
            DifficultyId = walk.DifficultyId,
            RegionId = walk.RegionId
        };
    }
}