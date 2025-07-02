using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class WalkRepository(Context context) : IWalkRepository
{
    public async Task<List<Walk>> GetAllAsync(
        string? filterOn = null,
        string? filterQuery = null,
        string? sortBy = null,
        bool isAscending = true,
        int pageNumber = 1,
        int pageSize = 1000)
    {
        // Start query
        var walksQuery = context.Walks
            .Include(w => w.Difficulty)
            .Include(w => w.Region)
            .AsQueryable();

        // Filtering
        if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walksQuery = walksQuery.Where(w => w.Name.Contains(filterQuery));
            }
        }

        // Sorting
        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            walksQuery = sortBy switch
            {
                var s when s.Equals("Name", StringComparison.OrdinalIgnoreCase) =>
                    isAscending ? walksQuery.OrderBy(w => w.Name) : walksQuery.OrderByDescending(w => w.Name),

                var s when s.Equals("Length", StringComparison.OrdinalIgnoreCase) =>
                    isAscending ? walksQuery.OrderBy(w => w.LengthInKm) : walksQuery.OrderByDescending(w => w.LengthInKm),

                var s when s.Equals("Id", StringComparison.OrdinalIgnoreCase) =>
                    isAscending ? walksQuery.OrderBy(w => w.Id) : walksQuery.OrderByDescending(w => w.Id),

                _ => walksQuery
            };
        }

        // Pagination
        var skipResults = (pageNumber - 1) * pageSize;

        return await walksQuery
            .Skip(skipResults)
            .Take(pageSize)
            .ToListAsync();
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