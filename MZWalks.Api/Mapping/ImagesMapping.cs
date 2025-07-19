using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Models.Domain;
using static ByteAether.Ulid.Ulid;

namespace MZWalks.Api.Mapping;

public static class ImagesMapping
{
    public static Image MapToImage(this CreateImageRequest request)
    {
        return new Image()
        {
            Id = New().ToString(),
            Name = request.Name,
            Description = request.Description,
            Extension = Path.GetExtension(request.File.Name),
            SizeInBytes = request.File.Length,
        };
    }
}