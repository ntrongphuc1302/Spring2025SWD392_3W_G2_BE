﻿using Microsoft.AspNetCore.Mvc;
using MetroOne.DAL;
using Microsoft.EntityFrameworkCore;
using MetroOne.DTO.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers;

[ApiController]
public class DebugController : ControllerBase
{
    private readonly MetroonedbContext _context;
    private readonly ILogger<DebugController> _logger;

    public DebugController(MetroonedbContext context, ILogger<DebugController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route(ApiRoutes.Debug.CheckDb)]
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
