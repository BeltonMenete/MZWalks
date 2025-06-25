using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Contracts.Response;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Mapping;

public static class DifficultiesMapping
{
    public static  Difficulty MapToDifficulty(this CreateDifficultyRequest request)
    {
        return new Difficulty()
        {
            Id = Guid.CreateVersion7(),
            Name = request.Name,
        };
    }

    
    public static DifficultyResponse MapToResponse(this Difficulty request)
    {
        return new DifficultyResponse
        {
            Id = request.Id,
            Name = request.Name,
        };
    }
}