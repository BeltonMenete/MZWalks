using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;

namespace MZWalks.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost(ApiEndpoints.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request) 
        {
            return Ok();
        }
    }
}
