using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public interface IRegionRepository
{
    Task<List<Region>> GetAllAsync();

    Task<Region?> GetById(string id);
    Task CreateAsync(Region region);
    Task UpdateAsync(Region region);
    Task DeleteAsync(Region region);
}