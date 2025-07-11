using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Contracts.Response;

public class WalkSummaryResponse
{
    public List<Walk> Items { get; set; } = new List<Walk>();
    public int Total { get; set; }
}