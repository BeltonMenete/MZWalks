using Microsoft.AspNetCore.Identity;

namespace MZWalks.Api.Repositories;

public interface ITokenRepository
{
    string CreateJwtToken(IdentityUser user, List<string> roles);
    
}