using System.ComponentModel.DataAnnotations;

namespace MZWalks.Api.Contracts.Requests;

public class RegisterRequest
{
    [DataType(DataType.EmailAddress)]
    public required string Username { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }

    public required string[] Roles { get; set; }
}