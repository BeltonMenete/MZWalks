using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        const string readerRoleId = "01JZBW2J6W23RS9VF147NZAJ22";
        const string writerRoleId = "01JZBWAXDKXG5G3TH5BKRWNFCG";
        
        var roles = new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
                
            },
            
            new IdentityRole()
            {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
                
            }
        };
    }
}