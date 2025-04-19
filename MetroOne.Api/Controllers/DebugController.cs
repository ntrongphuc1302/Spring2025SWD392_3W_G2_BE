using Microsoft.AspNetCore.Mvc;
using MetroOne.DAL;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Debug")]
public class DebugController : ControllerBase
{
    private readonly MetroonedbContext _context;
    private readonly ILogger<DebugController> _logger;

    public DebugController(MetroonedbContext context, ILogger<DebugController> logger)
    {
        _context = context;
        _logger = logger;
    }

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
}
