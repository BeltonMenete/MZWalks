using ByteAether.Ulid;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Contracts.Response;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Mapping;

public static class RegionsMapping
{
    public static Region MapToRegion(this CreateRegionRequest request)
    {
        return new Region()
        {
            Id = Ulid.New().ToGuid(),
            Code = request.Code,
            Name = request.Name,
            RegionImageURL = request.RegionImageURL
        };
    }

    public static Region MapUpdate(this Region region, UpdateRegionRequest request)
    {
        region.Code = request.Code;
        region.Name = request.Name;
        region.RegionImageURL = request.RegionImageURL;
        return region;
    }

    public static RegionResponse MapToResponse(this Region region)
    {
        return new RegionResponse()
        {
            Id = Ulid.New(region.Id).ToString(),
            Code = region.Code,
            Name = region.Name,
            RegionImageURL = region.RegionImageURL
        };
    }
}