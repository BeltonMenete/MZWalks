
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MZWalks.Api.Data;

public class AuthContext(DbContextOptions<AuthContext> options): IdentityDbContext(options)
{
    
}