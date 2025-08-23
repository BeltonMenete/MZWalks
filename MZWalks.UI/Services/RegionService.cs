
using MZWalks.UI.Models.DTOs;
using RestSharp;
using Method = RestSharp.Method;

public class RegionService
{
    private readonly RestClient _client;

    public RegionService(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    public async Task<List<RegionDto>> GetRegionsAsync()
    {
        try
        {
            var request = new RestRequest("api/regions", Method.Get);

            var response = await _client.ExecuteAsync<List<RegionDto>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                // You could log the error here: response.ErrorMessage
                return new List<RegionDto>();
            }

            return response.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<RegionDto> GetRegionAsync(string id)
    {
        var request = new RestRequest($"api/regions/{id}", Method.Get);

        var response = await _client.ExecuteAsync<RegionDto>(request);
        if (!response.IsSuccessful || response.Data == null)
        {
            // You could log the error here: response.ErrorMessage
            return new RegionDto();
        }

        return response.Data;
    }
    
    public async Task<RestResponse> CreateRegionsAsync(CreateRegionDto newRegion)
    {
        var request = new RestRequest("api/regions", Method.Post);
        
        request.AddJsonBody(newRegion);

        var response = await _client.ExecuteAsync(request);

        return response;
    }

    public async Task<RestResponse> DeleteRegionAsync(string id)
    {
        var request = new RestRequest($"api/regions/{id}",Method.Delete);

        var response = await _client.ExecuteAsync(request);
        return response;
    }
    
    public async Task<RestResponse> UpdateRegionAsync(UpdateRegionDto region)
    {
        var request = new RestRequest($"api/regions",Method.Put);
        request.AddJsonBody(region);
        
        var response = await _client.ExecuteAsync(request);
        return response;
    }
    
}