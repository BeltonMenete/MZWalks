using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class WalkRepository(Database database) : IWalkRepository
{
    public async Task<List<Walk>> GetAllAsync()
    {
        return await database.Walks.ToListAsync();
    }

    public async Task<Walk?> GetById(Guid id)
    {
        return await database.Walks.FindAsync(id);
    }

    public async Task<string?> CreateAsync(Walk walk)
    {
        if (!await database.Difficulties.AnyAsync((d) => d.Id == walk.DifficultyId))
            return "Difficulty does  not exist";
        if (!await database.Regions.AnyAsync((r) => r.Id == walk.RegionId))
            return "region does  not exist";
        

        await database.Walks.AddAsync(walk);
        await database.SaveChangesAsync();
        return null;
    }

    public async Task<string?> UpdateAsync(Walk walk)
    {
        if (!await database.Difficulties.AnyAsync((d) => d.Id == walk.DifficultyId))
            return "Difficulty does  not exist";
        if (!await database.Regions.AnyAsync((r) => r.Id == walk.RegionId))
            return "region does  not exist";
        
        database.Walks.Update(walk);
        await database.SaveChangesAsync();
        return null;
    }

    public async Task DeleteAsync(Walk walk)
    {
        database.Walks.Remove(walk);
        await database.SaveChangesAsync();
    }
}