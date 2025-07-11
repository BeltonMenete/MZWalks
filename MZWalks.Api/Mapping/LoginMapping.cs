using MZWalks.Api.Contracts.Response;

namespace MZWalks.Api.Mapping;

public static class LoginMapping
{
    public static LoginResponse MapToRespose(this string jwtToken)
    {
        return new LoginResponse()
        {
            JwtToken = jwtToken
        };
    }
}