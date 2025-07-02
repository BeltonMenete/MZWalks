using System.ComponentModel.DataAnnotations;

namespace MZWalks.Api.Models.Domain;

public class Difficulty
{
    [MaxLength(26)]
    public required string Id { get; set; }
    public string Name { get; set; }
}