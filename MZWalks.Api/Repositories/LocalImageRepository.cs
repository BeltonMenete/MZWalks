using ByteAether.Ulid;
using MZWalks.Api.Data;
using MZWalks.Api.Models.Domain;
namespace MZWalks.Api.Repositories;

public class LocalImageRepository : IImageRepository
{
    private readonly Context _context; // Your database context
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LocalImageRepository(Context context, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Image> Upload(Image image)
    {
        // 1. Construct the base directory for uploads
        // This will be, for example: C:\YourApp\MZWalks.Api\Images
        var uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Images");

        // Ensure the 'Images' directory exists. Create it if it doesn't.
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName = Ulid.New().ToString() + image.Extension; // Use image.Extension which is now correct

        var localFilePath = Path.Combine(uploadsFolder, uniqueFileName);
        
        using (var stream = new FileStream(localFilePath, FileMode.Create))
        {
            // This copies the content of the uploaded file to the local file system
            await image.File.CopyToAsync(stream);
        }

        // 5. Construct the URL path to access the uploaded image via HTTP
        // This path must match how you configure static files middleware.
        // Example: https://localhost:2001/Images/unique-ulid.png
        var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://" +
                          $"{_httpContextAccessor.HttpContext.Request.Host}" +
                          $"{_httpContextAccessor.HttpContext.Request.PathBase}" +
                          $"/Images/{uniqueFileName}"; // Consistent with the folder name "Images" and unique filename

        // Update the Image domain model with the path and the actual unique filename saved
        image.Path = urlFilePath;

        image.Name = uniqueFileName; // If Name is intended to be the actual filename

        // 6. Add image metadata to the database
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();

        return image; // Return the updated image object with its path
    }
}