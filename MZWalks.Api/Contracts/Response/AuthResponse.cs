namespace MZWalks.Api.Contracts.Response;

public class AuthResponse
{
    public required string Token { get; set; }
    public string RefreshToken { get; set; }  // optional
    public DateTime Expiration { get; set; }  // optional
    public string UserName { get; set; }      // optional
}