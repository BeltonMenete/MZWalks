using System.ComponentModel.DataAnnotations;

namespace MZWalks.Api.Contracts.Requests;

public class RegisterRequest
{
    [DataType(DataType.EmailAddress)] public required string UserName { get; set; }
    [DataType(DataType.EmailAddress)] public required string Password { get; set; }
    public required string[] Roles { get; set; }
}