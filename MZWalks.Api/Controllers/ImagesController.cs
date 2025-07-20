using Microsoft.AspNetCore.Mvc;
using MZWalks.Api;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;
using MZWalks.Api.Validators;

[ApiController]
[Route("api/[controller]")] // This will make the base route /api/images
public class ImagesController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    // Assuming ApiEndpoints.Images.Upload might be something like "[action]" or a specific route
    // If your route is /api/images, then [HttpPost] is sufficient.
    // If it's /api/images/upload, then [HttpPost("upload")]
    [ValidateModel] // Ensure this custom filter correctly handles ModelState.IsValid
    [HttpPost(ApiEndpoints.Images.Upload)] // Or [HttpPost("upload")] if your route needs it more specific
    [EndpointSummary("Upload image")] // If this is a custom attribute, ensure it's defined
    public async Task<IActionResult> Upload([FromForm] CreateImageRequest request)
    {
        // Your custom file validation
        ValidateFileUpload(request);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Map DTO to Domain model, now correctly transferring the IFormFile
        var image = request.MapToImage();

        // Repository to add image and save it locally
        var uploadedImage = await _imageRepository.Upload(image);

        // Map domain model back to DTO for response if needed, or return domain model directly
        // For simplicity, returning the domain model here.
        return Ok(uploadedImage);
    }

    private void ValidateFileUpload(CreateImageRequest request)
    {
        // Check if the file itself is null (should be caught by [Required] on DTO if present)
        if (request.File == null)
        {
            ModelState.AddModelError("File", "No file uploaded.");
            return;
        }

        var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

        // Use request.File.FileName to get the actual uploaded file's extension
        var fileExtension = Path.GetExtension(request.File.FileName)?.ToLowerInvariant();

        if (!allowedExtensions.Contains(fileExtension))
        {
            ModelState.AddModelError("File", "Invalid file extension. Only .jpg, .jpeg, .png are allowed.");
        }

        // 10 MB in bytes (10 * 1024 * 1024)
        if (request.File.Length > 10485760)
        {
            ModelState.AddModelError("File", "File size exceeds 10MB. Please upload a smaller size.");
        }
    }
}