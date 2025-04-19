using Microsoft.AspNetCore.Mvc;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Constants;

namespace Backend.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "Users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut]
    [Route(ApiRoutes.Users.Update)]
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

    [HttpDelete]
    [Route(ApiRoutes.Users.Delete)] 
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
    [Route(ApiRoutes.Users.GetAll)]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet]
    [Route(ApiRoutes.Users.GetById)]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
