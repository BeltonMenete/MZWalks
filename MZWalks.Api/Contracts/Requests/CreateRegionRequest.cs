namespace MZWalks.Api.Contracts.Requests;

public class CreateRegionRequest
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string RegionImageURL { get; set; }
}