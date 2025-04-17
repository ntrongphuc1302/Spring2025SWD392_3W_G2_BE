using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MetroOne.DAL;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetroOneController : ControllerBase
    {
        private readonly MetroonedbContext _context;
        private readonly ILogger<MetroOneController> _logger;

        public MetroOneController(MetroonedbContext context, ILogger<MetroOneController> logger)
        {
            _context = context;
            _logger = logger;
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
