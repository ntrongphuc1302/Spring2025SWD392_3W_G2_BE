using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetroOne.DAL;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;
using MetroOne.DTO.Requests;

using Microsoft.Extensions.Logging;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.BLL.Services.Implementations;
using MetroOne.DTO.Responses;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetroOneController : ControllerBase
    {
        private readonly MetroonedbContext _context;
        private readonly ILogger<MetroOneController> _logger;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public MetroOneController(MetroonedbContext context, ILogger<MetroOneController> logger, IAuthService authService, IUserService userService, IUserRepository userRepository)
        {
            _context = context;
            _logger = logger;
            _authService = authService;
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto)
        {
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest dto)
        {
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

        [HttpPut("user/update")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest dto)
        {
            try {
                var success = await _userService.UpdateUserAsync(dto);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpDelete("user/delete/")]
        public async Task<IActionResult> SoftDeleteUser(DeleteUserRequest userId)
        {
            try
            {
                if (userId == null || userId.UserId <= 0)
                    return BadRequest("Invalid user ID");
                var id = userId.UserId;
                var success = await _userService.SoftDeleteUserAsync(id);
                if (success)
                    return Ok("User deleted successfully");
                else
                    return NotFound("User not found or already deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        #region DEBUG
        // GET: /MetroOne/CheckDatabaseConnection
        [HttpGet("CheckDatabaseConnection")]
        public IActionResult CheckDatabaseConnection()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("SELECT * from users"); 

                return Ok("Database connection successful.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Database connection failed.");
                return StatusCode(500, "Database connection failed: " + ex.Message);
            }
        }
        #endregion
    }
}
