using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class RegionRepository(Database database) : IRegionRepository
{
    public async Task<List<Region>> GetAllAsync()
    {
        return await database.Regions.ToListAsync();
    }

    public async Task<Region?> GetById(Guid id)
    {
        return await database.Regions.FindAsync(id);
    }

    public async Task CreateAsync(Region region)
    {
        await database.Regions.AddAsync(region);
        await database.SaveChangesAsync();
    }

    public async Task UpdateAsync(Region region)
    {
        database.Regions.Update(region);
        await database.SaveChangesAsync();
    }

    public async Task DeleteAsync(Region region)
    {
        database.Regions.Remove(region);
        await database.SaveChangesAsync();
    }
}