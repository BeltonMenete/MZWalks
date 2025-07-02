using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class RegionRepository : IRegionRepository
{
    private readonly Context _context;
    public RegionRepository(Context context)
    {
        _context = context;
    }
    public async Task<List<Region>> GetAllAsync()
    {
        return await _context.Regions.ToListAsync();
    }

    public async Task<Region?> GetById(string id)
    {
        return await _context.Regions.FindAsync(id);
    }

    public async Task CreateAsync(Region region)
    {
        await _context.Regions.AddAsync(region);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Region region)
    {
        _context.Regions.Update(region);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Region region)
    {
        _context.Regions.Remove(region);
        await _context.SaveChangesAsync();
    }
}