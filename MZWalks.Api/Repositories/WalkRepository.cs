using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class WalkRepository(Context context) : IWalkRepository
{
    public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
        string? sortBy = null, bool isAscending = true, int? pageNumber = 1, int? pageSize = 1000)
    {
        var walks = context
            .Walks
            .Include(w => w.Difficulty)
            .Include((w) => w.Region)
            .AsQueryable();
        // Filtering
        if (!string.IsNullOrEmpty(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where((w) => w.Name.Contains(filterQuery));
            }
        }

        // Sorting
        if (string.IsNullOrEmpty(sortBy)) return await walks.ToListAsync();
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy((w) => w.Name) : walks.OrderByDescending(w => w.Name);
            }
            else if (sortBy.Equals("Length", StringComparison.InvariantCultureIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy((w) => w.LengthInKm) : walks.OrderByDescending(w => w.LengthInKm);
            }
            else if (sortBy.Equals("Id", StringComparison.InvariantCultureIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(w => w.Id) : walks.OrderByDescending(w => w.Id);
            }
        }
        // Pagination


        return await walks.ToListAsync();
    }

    public async Task<Walk?> GetById(string id)
    {
        return await context.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync((w) => w.Id == id);
    }

    public async Task<string?> CreateAsync(Walk walk)
    {
        await context.Walks.AddAsync(walk);
        await context.SaveChangesAsync();
        return null;
    }

    public async Task<string?> UpdateAsync(Walk walk)
    {
        context.Walks.Update(walk);
        await context.SaveChangesAsync();
        return null;
    }


    public async Task DeleteAsync(Walk walk)
    {
        context.Walks.Remove(walk);
        await context.SaveChangesAsync();
    }
}