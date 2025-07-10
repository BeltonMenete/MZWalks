using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace MZWalks.Api.Repositories;

public class TokenRepository : ITokenRepository
{
    private readonly IConfiguration _configuration;
    public TokenRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string CreateJwtToken(IdentityUser user, List<string> roles)
    {
        // Create claims
        var claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Email, user.Email));

        // Add role claims using LINQ
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        return "ok";
    }
}