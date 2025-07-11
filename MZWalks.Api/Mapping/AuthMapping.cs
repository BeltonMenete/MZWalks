using MZWalks.Api.Contracts.Response;

namespace MZWalks.Api.Mapping;

public static class AuthMapping
{
    public static AuthResponse MapToRespose(this string jwtToken)
    {
        return new AuthResponse()
        {
            JwtToken = jwtToken
        };
    }
}