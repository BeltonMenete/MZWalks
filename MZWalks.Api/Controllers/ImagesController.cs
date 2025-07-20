
using Microsoft.AspNetCore.Mvc;
using MZWalks.Api;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Models.Domain;
using MZWalks.Api.Repositories;

[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    
    [HttpPost(ApiEndpoints.Images.Upload)]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Image))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [Produces("application/json")]
    public async Task<IActionResult> Upload([FromForm] CreateImageRequest request)
    {
        ValidateFileUpload(request);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var image = request.MapToImage();

        var uploadedImage = await _imageRepository.Upload(image);
        return Ok(uploadedImage);
    }

    private void ValidateFileUpload(CreateImageRequest request)
    {
        if (request.File == null)
        {
            ModelState.AddModelError("File", "No file uploaded.");
            return;
        }

        var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

        var fileExtension = Path.GetExtension(request.File.FileName)?.ToLowerInvariant();

        if (!allowedExtensions.Contains(fileExtension))
        {
            ModelState.AddModelError("File", "Invalid file extension. Only .jpg, .jpeg, .png are allowed.");
        }

        if (request.File.Length > 10485760)
        {
            ModelState.AddModelError("File", "File size exceeds 10MB. Please upload a smaller size.");
        }
    }
}
