using Microsoft.AspNetCore.Mvc;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Requests;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiExplorerSettings(GroupName = "Users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest dto)
    {
        try
        {
            var success = await _userService.UpdateUserAsync(dto);
            return Ok("User updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> SoftDeleteUser(DeleteUserRequest userId)
    {
        try
        {
            if (userId == null || userId.UserId <= 0)
                return BadRequest("Invalid user ID");

            var success = await _userService.SoftDeleteUserAsync(userId.UserId);
            return success ? Ok("User deleted successfully") : NotFound("User not found or already deleted");
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}
