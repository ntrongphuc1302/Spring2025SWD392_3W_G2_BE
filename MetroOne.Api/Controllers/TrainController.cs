using Microsoft.AspNetCore.Mvc;
using MetroOne.DAL;
using Microsoft.EntityFrameworkCore;
using MetroOne.DTO.Constants;
using MetroOne.BLL.Services.Interfaces;

namespace MetroOne.API.Controllers;

[ApiController]

public class TrainController
{
    private readonly IUserService _userService;

    public TrainController(IUserService userService)
    {
        _userService = userService;
    }
}
