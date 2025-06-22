using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Data;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Region> Regions { get; set; } 
    public DbSet<Walk> Difficulties { get; set; } 
}