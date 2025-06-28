using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class WalkRepository(Database database) : IWalkRepository
{
    public async Task<List<Walk>> GetAllAsync()
    {
        return await database
            .Walks
            .Include(w => w.Difficulty)
            .Include((w) => w.Region)
            .ToListAsync();
    }

    public async Task<Walk?> GetById(Guid id)
    {
        return await database.Walks.FirstOrDefaultAsync((w)=> w.Id == id);
    }

    public async Task<string?> CreateAsync(Walk walk)
    {
  
        await database.Walks.AddAsync(walk);
        await database.SaveChangesAsync();
        return null;
    }

    public async Task<string?> UpdateAsync(Walk walk)
    {
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