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
            Id = Guid.CreateVersion7(),
            Name = request.Name,
            Description = request.Description,
            LengthInKm = request.LengthInKm,
            WalkImageURl = request.WalkImageURl,
            //DifficultyId = Ulid.Parse(request.DifficultyId).ToByteArray(),
            //RegionId = request.RegionId
        };
    }

    public static Walk MapUpdate(this Walk walk, UpdateWalkRequest request)
    {
        walk.Name = request.Name;
        walk.Description = request.Description;
        walk.LengthInKm = request.LengthInKm;
        walk.WalkImageURl = request.WalkImageURl;
        walk.DifficultyId = Ulid.Parse(request.DifficultyId).ToByteArray();
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
            Difficulty = walk.Difficulty.MapToResponse() ?? null,
            Region = walk.Region != null ? walk.Region.MapToResponse() : null
        };
    }
}