using ByteAether.Ulid;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Models.Domain;

using System.Text.RegularExpressions;

public static class ImagesMapping
{
    public static Image MapToImage(this CreateImageRequest request)
    {
        return new Image
        {
            Id = Ulid.New().ToString(),
            File = request.File,
            Name = request.Name?.ToSlug(),
            Description = request.Description?.Trim(),
            Extension = Path.GetExtension(request.File.FileName)?.ToLowerInvariant() ?? string.Empty,
            SizeInBytes = request.File.Length,
            Path = string.Empty
        };
    }

    // Private helper method scoped to this file
    private static string ToSlug(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var cleaned = new string(input
            .Trim()
            .ToLowerInvariant()
            .Select(c => char.IsLetterOrDigit(c) ? c : (c == ' ' ? '-' : '\0'))
            .Where(c => c != '\0')
            .ToArray());

        return Regex.Replace(cleaned, "-{2,}", "-").Trim('-');
    }
}
