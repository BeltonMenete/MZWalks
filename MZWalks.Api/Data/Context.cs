using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Difficulties
        modelBuilder.Entity<Difficulty>().HasData(
            new Difficulty { Id = "01HZX0J5ZWGFA1D9S3H4HMGWVD", Name = "Easy" },
            new Difficulty { Id = "01HZX0J5ZX9Y9S9TCS59R3KH9J", Name = "Medium" },
            new Difficulty { Id = "01HZX0J60AZK3D9R9YFMC2DJMD", Name = "Hard" }
        );

        // Seed Regions
        modelBuilder.Entity<Region>().HasData(
            new Region { Id = "01HZX0J60B8J1A8RPX1M0XQJ3N", Code = "AKL", Name = "Auckland", RegionImageURL = "https://images.nzregions.com/auckland.jpg" },
            new Region { Id = "01HZX0J60C1J1A8RPX2N1YQJ3P", Code = "WGN", Name = "Wellington", RegionImageURL = "https://images.nzregions.com/wellington.jpg" },
            new Region { Id = "01HZX0J60D1J1A8RPX3Z2ZQJ3Q", Code = "CAN", Name = "Canterbury", RegionImageURL = "https://images.nzregions.com/canterbury.jpg" },
            new Region { Id = "01HZX0J60E1J1A8RPX4P3AQJ3R", Code = "STL", Name = "Southland", RegionImageURL = "https://images.nzregions.com/southland.jpg" },
            new Region { Id = "01HZX0J60F1J1A8RPX5D4BQJ3S", Code = "OTA", Name = "Otago", RegionImageURL = "https://images.nzregions.com/otago.jpg" }
        );
    }
}