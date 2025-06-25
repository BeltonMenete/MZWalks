using System.ComponentModel.DataAnnotations;

namespace MZWalks.Api.Contracts.Requests;

public class CreateRegionRequest
{
    [MaxLength(3, ErrorMessage = "Code has to be of maximum of 3 characters")]
    [MinLength(2, ErrorMessage = "Code Has To Be Of minimum 2 Characters")]
    public required string Code { get; set; } = string.Empty;
    [MaxLength(100, ErrorMessage = "Code has to be of maximum of 100 characters")]
    public string Name { get; set; } = string.Empty;
    public string RegionImageURL { get; set; }
}