using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetroOne.DAL;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;
using MetroOne.DTO.Requests;

using Microsoft.Extensions.Logging;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.BLL.Services.Implementations;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetroOneController : ControllerBase
    {
        private readonly MetroonedbContext _context;
        private readonly ILogger<MetroOneController> _logger;
        private readonly IAuthService _authService;

        public MetroOneController(MetroonedbContext context, ILogger<MetroOneController> logger, IAuthService authService)
        {
            _context = context;
            _logger = logger;
            _authService = authService;
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
