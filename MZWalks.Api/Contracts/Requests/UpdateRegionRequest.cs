using System.ComponentModel.DataAnnotations;

namespace MZWalks.Api.Contracts.Requests;

public class UpdateRegionRequest
{
    [MaxLength(3, ErrorMessage = "Code has to be 3 to 3 characters")]
    [MinLength(3, ErrorMessage = "Code has to be 3 to 3 characters")]
    public string Code { get; set; } = string.Empty;
    [MaxLength(3, ErrorMessage = "Code has to be 3 to 3 characters")]
    public string Name { get; set; } = string.Empty;
    public string RegionImageURL { get; set; }
}