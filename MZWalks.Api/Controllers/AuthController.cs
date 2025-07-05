using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;

namespace MZWalks.Api.Controllers
{
    [ApiController]
    public class AuthController(UserManager<IdentityUser> userManager) : ControllerBase
    {
        [HttpPost(ApiEndpoints.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var newIdentityUser = new IdentityUser()
            {
                UserName = request.UserName,
                Email = request.UserName
            };

            var newIdentityResult = await userManager.CreateAsync(newIdentityUser, request.Password);

            if (newIdentityResult.Succeeded)
            {
                // Add Roles To this user
                
            }
            return Ok();
        }
    }
}