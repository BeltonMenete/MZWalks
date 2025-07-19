namespace MZWalks.Api.Contracts.Requests;

public class CreateImageRequest
{
    public required IFormFile File { get; set; }
    public required string Name { get; set; }

    public string? Description { get; set; }

    public string Extension { get; set; }
    // public long SizeInBytes { get; set; }
    // public string Path { get; set; }
}