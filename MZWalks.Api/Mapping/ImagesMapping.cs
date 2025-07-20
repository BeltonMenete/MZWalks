using ByteAether.Ulid;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Models.Domain;

public static class ImagesMapping
{
    public static Image MapToImage(this CreateImageRequest request)
    {
        return new Image()
        {
            Id = Ulid.New().ToString(),
            File = request.File,
            Name = request.Name,
            Description = request.Description,
            // Extension = Path.GetExtension(request.File.FileName)?.ToLowerInvariant() ?? string.Empty,
            // SizeInBytes = request.File.Length,
            // Path = string.Empty // This will be populated by the repository after saving the file
        };
    }
}