using ByteAether.Ulid;
using MZWalks.Api.Contracts.Response;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Mapping;

public static class DifficultiesMapping
{
    public static DifficultyResponse MapToResponse(this Difficulty difficulty)
    {
        return new DifficultyResponse()
        {
            Id = difficulty.Id,
            Name = difficulty.Name,
        };
    }
}