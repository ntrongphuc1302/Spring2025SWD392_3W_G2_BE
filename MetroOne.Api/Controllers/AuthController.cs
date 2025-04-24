using Microsoft.AspNetCore.Mvc;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Constants;

namespace Backend.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    /// <summary>
    /// Login a user 
    /// </summary>
    /// 
    [HttpPost]
    
    [Route(ApiRoutes.Auth.Login)]
    public async Task<IActionResult> Login([FromBody] LoginRequest dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Login failed.");
            return Unauthorized(new { message = "Invalid email or password" });
        }
    }

    /// <summary>
    /// Register a new user
    /// </summary>
    [HttpPost]
    [Route(ApiRoutes.Auth.Register)]
    public async Task<IActionResult> Register(RegisterRequest dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
