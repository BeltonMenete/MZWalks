using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class RegionRepository(Context context) : IRegionRepository
{
    public async Task<List<Region>> GetAllAsync()
    {
        return await context.Regions.ToListAsync();
    }

    public async Task<Region?> GetById(string id)
    {
        return await context.Regions.FindAsync(id);
    }

    public async Task CreateAsync(Region region)
    {
        await context.Regions.AddAsync(region);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Region region)
    {
        context.Regions.Update(region);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Region region)
    {
        context.Regions.Remove(region);
        await context.SaveChangesAsync();
    }
}