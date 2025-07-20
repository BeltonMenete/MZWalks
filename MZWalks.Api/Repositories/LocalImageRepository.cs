using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class LocalImageRepository : IImageRepository
{
    private readonly Context _context;
    private readonly IWebHostEnvironment _env;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string ImageFolder = "Images";

    public LocalImageRepository(Context context, 
        IWebHostEnvironment env, 
        IHttpContextAccessor accessor)
    {
        _context = context;
        _env = env;
        _httpContextAccessor = accessor;
    }

    public async Task<Image> Upload(Image image)
    {
        var fileName = $"{image.Name}{image.Extension}";
        var localFolderPath = Path.Combine(_env.ContentRootPath, ImageFolder);
        var localFilePath = Path.Combine(localFolderPath, fileName);

        Directory.CreateDirectory(localFolderPath);

        using var stream = new FileStream(localFilePath, FileMode.Create);
        await image.File.CopyToAsync(stream);

        var request = _httpContextAccessor.HttpContext.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
        image.Path = $"{baseUrl}/{ImageFolder}/{fileName}";

        _context.Images.Add(image);
        await _context.SaveChangesAsync();
        return image;
    }
}