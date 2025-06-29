using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public interface IWalkRepository
{
    Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null,
        bool isAscending = true);

    Task<Walk?> GetById(Guid id);
    Task<string?> CreateAsync(Walk walk);
    Task<string?> UpdateAsync(Walk walk);
    Task DeleteAsync(Walk walk);
}