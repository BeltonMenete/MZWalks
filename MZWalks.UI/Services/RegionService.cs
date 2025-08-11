using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using MZWalks.Api.Models.Domain;
using RestSharp;

public class RegionService
{
    private readonly RestClient _client;

    public RegionService(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<List<Region>> GetRegionsAsync()
    {
        var request = new RestRequest("api/regions");

        var response = await _client.ExecuteAsync<List<Region>>(request);

        if (!response.IsSuccessful || response.Data == null)
        {
            // You could log the error here: response.ErrorMessage
            return new List<Region>();
        }

        return response.Data;
    }
}