using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;

namespace MZWalks.Api.Repositories;

public class LocalImageRepository : IImageRepository
{
    private readonly Context _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LocalImageRepository(Context context, IWebHostEnvironment hostingEnvironment, IHttpContextAccessor accessor)
    {
        _context = context;
        _webHostEnvironment = hostingEnvironment;
        _httpContextAccessor = accessor;
    }

    public async Task<Image> Upload(Image image)
    {
        var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath,
            "Images",
            image.Name,
            image.Extension);
        // upload image to local path
        using var stream = new FileStream(localFilePath, FileMode.Create);
        await image.File.CopyToAsync(stream);

        //https://localhost:2001/api/images/upload

        var ulrFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}:" +
                          $"//{_httpContextAccessor.HttpContext.Request.Host}" +
                          $"{_httpContextAccessor.HttpContext.Request.PathBase}" +
                          $"/images/{image.Name}" +
                          $"/{image.Extension}";
        image.Path = ulrFilePath;
        // Add image to db
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();
        return image;
    }
}