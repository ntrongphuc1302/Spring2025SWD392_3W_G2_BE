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
            var result = await _authService.LoginAsync(dto);
            if (result == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (result == null)
                return BadRequest("Email is already in use");

            return Ok(result);
        }

        [HttpPut("user/update")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest dto)
        {
            var success = await _userService.UpdateUserAsync(dto);
            if (!success) return NotFound("User not found");

            return Ok("User updated successfully");
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
