using System.ComponentModel.DataAnnotations;

namespace MZWalks.Api.Models.Domain;

public class Region
{ 
    [MaxLength(26)]
    public required string Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string RegionImageURL { get; set; }

}