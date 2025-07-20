using Microsoft.AspNetCore.Mvc;
using MZWalks.Api;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;
using MZWalks.Api.Validators;

[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    
    [HttpPost(ApiEndpoints.Images.Upload)]
    [EndpointSummary("Upload image")] 
    public async Task<IActionResult> Upload([FromForm] CreateImageRequest request)
    {
        // my custom file validation
        ValidateFileUpload(request);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Map DTO to Domain model, now correctly transferring the IFormFile
        var image = request.MapToImage();

        // Repository to add image and save it locally
        var uploadedImage = await _imageRepository.Upload(image);
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