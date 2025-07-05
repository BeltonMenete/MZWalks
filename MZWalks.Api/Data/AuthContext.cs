using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MZWalks.Api.Data;

public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext(options)
{
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
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}