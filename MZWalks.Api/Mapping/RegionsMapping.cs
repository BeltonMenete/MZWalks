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
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            RegionImageURL = request.RegionImageURL
        };
    }

    public static Region MapToRegion(this UpdateRegionRequest request, Guid id)
    {
        return new Region()
        {
            Id = id,
            Code = request.Code,
            Name = request.Name,
            RegionImageURL = request.RegionImageURL
        };
    }

    public static RegionResponse MapToResponse(this Region region)
    {
        return new RegionResponse()
        {
            Id = region.Id,
            Code = region.Code,
            Name = region.Name,
            RegionImageURL = region.RegionImageURL
        };
    }
}