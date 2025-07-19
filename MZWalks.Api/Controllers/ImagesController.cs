using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Validators;

namespace MZWalks.Api.Controllers;

[ApiController]
public class ImagesController : ControllerBase
{
    [ValidateModel]
    [HttpPost(ApiEndpoints.Images.Upload)]
    [EndpointSummary("Upload image")]
    public async Task<IActionResult> Upload([FromForm] CreateImageRequest request)
    {
        ValidateFileUpload(request);
        return Created();
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