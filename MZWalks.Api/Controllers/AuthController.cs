using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using MZWalks.Api.Contracts.Requests;
using MZWalks.Api.Mapping;
using MZWalks.Api.Repositories;
using MZWalks.Api.Contracts.Response;

namespace MZWalks.Api.Controllers;

[ApiController]
[Tags("Authentication")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenRepository _tokenRepository;

    public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
    {
        _userManager = userManager;
        _tokenRepository = tokenRepository;
    }

    [HttpPost(ApiEndpoints.Auth.Register)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [EndpointSummary("Registers a new user with roles.")]
    public async Task<IActionResult> Register([FromBody] AuthRegisterRequest request)
    {
        var user = new IdentityUser
        {
            UserName = request.Username,
            Email = request.Username
        };

        var createResult = await _userManager.CreateAsync(user, request.Password);
        if (!createResult.Succeeded)
            return BadRequest(createResult.Errors);

        var roleResult = await _userManager.AddToRolesAsync(user, request.Roles);
        if (!roleResult.Succeeded)
            return BadRequest(roleResult.Errors);

        return Ok("New user was registered");
    }

    [HttpPost(ApiEndpoints.Auth.Login)]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Authenticates user and returns a JWT token.")]
    public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Username);
        if (user is null)
            return NotFound("User not found");

        var isValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isValid)
            return BadRequest("Incorrect password");

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenRepository.CreateJwtToken(user, roles.ToList());

        return Ok(token.MapToResponse());
    }
}
