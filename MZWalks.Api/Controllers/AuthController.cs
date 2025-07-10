using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;

namespace MZWalks.Api.Controllers
{
    [Route("api/[controller]")] // ✅ Added Route
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost(ApiEndpoints.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var newIdentityUser = new IdentityUser()
            {
                UserName = request.Username,
                Email = request.Username
            };

            var newIdentityResult = await _userManager.CreateAsync(newIdentityUser, request.Password);

            if (!newIdentityResult.Succeeded)
            {
                return BadRequest(newIdentityResult.Errors); // ✅ Better error info
            }

            var roleResult = await _userManager.AddToRolesAsync(newIdentityUser, request.Roles);
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors); // ✅ Return role add errors
            }

            return Ok("New user was registered");
        }
    }
}