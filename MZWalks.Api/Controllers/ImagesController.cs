using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;
using MZWalks.Api.Validators;

namespace MZWalks.Api.Controllers;

[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    [ValidateModel]
    [HttpPost(ApiEndpoints.Images.Upload)]
    [EndpointSummary("Upload image")]
    public async Task<IActionResult> Upload([FromForm] CreateImageRequest request)
    {
        ValidateFileUpload(request);
        if (!ModelState.IsValid) return BadRequest(ModelState);
        //repository to add image
        var image = await _imageRepository.Upload(request.MapToImage());
        return Ok(image);
    }


    private void ValidateFileUpload(CreateImageRequest request)
    {
        var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
        if (!allowedExtensions.Contains(Path.GetExtension(request.Name)))
        {
            ModelState.AddModelError("File", "Invalid file extension");
        }

        if (request.File.Length > 10485760)
        {
            ModelState.AddModelError("File", "It is more than 10MB, please upload smaller size");
        }
    }
}