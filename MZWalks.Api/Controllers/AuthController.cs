using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;

namespace MZWalks.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        // Register
        [HttpPost(ApiEndpoints.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] AuthRegisterRequest request)
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

        // Login
        [HttpPost(ApiEndpoints.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Username);
            if (user is null) return NotFound("User not Found");
            
            var userPassword = await _userManager.CheckPasswordAsync(user , request.Password);
            if (!userPassword) return BadRequest(("Incorrect Password"));
            
            var roles = await _userManager.GetRolesAsync(user);
            var jwtoken = _tokenRepository.CreateJwtToken(user, roles.ToList());
            return Ok(jwtoken.MapToRespose());
        }
    }
}