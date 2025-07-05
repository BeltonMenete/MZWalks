using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }
    
}