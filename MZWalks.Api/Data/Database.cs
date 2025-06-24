using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Data;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Region> Regions { get; set; } 
    public DbSet<Difficulty> Difficulties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var difficulties = new List<Difficulty>()
        {
            new()
            {
                Id = Guid.Parse("14a66713-2414-4831-84a4-33a7bcd08b1c"),
                Name = "Hard"
            },
            new()
            {
                Id = Guid.Parse("e89b2659-7259-46ef-8c09-9b8055ac29e4"),
                Name = "Medium"
            },
            new()
            {
                Id = Guid.Parse("07bbe860-ed98-4431-9934-9775d6c2ea1e"),
                Name = "easy"
            },
        };

        modelBuilder.Entity<Difficulty>().HasData(difficulties);
    }
}