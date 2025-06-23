namespace MZWalks.Api.Contracts.Requests;

public class UpdateRegionRequest
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string RegionImageURL { get; set; }
}