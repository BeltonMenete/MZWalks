using ByteAether.Ulid;
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
            Id = Ulid.New().ToString(),
            Name = request.Name,
            Description = request.Description,
            LengthInKm = request.LengthInKm,
            WalkImageURl = request.WalkImageURl,
            DifficultyId = request.DifficultyId,
            RegionId = request.RegionId
        };
    }

    public static Walk MapUpdate(this Walk walk, UpdateWalkRequest request)
    {
        walk.Name = request.Name;
        walk.Description = request.Description;
        walk.LengthInKm = request.LengthInKm;
        walk.WalkImageURl = request.WalkImageURl;
        walk.DifficultyId = request.DifficultyId;
        walk.RegionId = request.RegionId;
        return walk;
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
            Difficulty = walk.Difficulty != null ? walk.Difficulty.MapToResponse() : null,
            Region = walk.Region != null ? walk.Region.MapToResponse() : null
        };
    }

    public static WalkSummaryResponse MapToList(this List<Walk> requests)
    {
        return new WalkSummaryResponse()
        {
            //Items = requests,
            Total = requests.Count
        };
    }
}