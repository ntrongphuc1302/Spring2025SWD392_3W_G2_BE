using Microsoft.AspNetCore.Mvc;
using MetroOne.DAL;
using Microsoft.EntityFrameworkCore;
using MetroOne.DTO.Constants;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Requests;
using MetroOne.DAL.Models;
using MetroOne.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using MetroOne.BLL.Services.Implementations;

namespace MetroOne.API.Controllers
{
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _trainService;
        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        [Route(ApiRoutes.Train.GetAll)]
        public async Task<IActionResult> Index()
        {
            var trains = await _trainService.GetAllTrainsAsync();
            if (trains == null)
            {
                return NotFound("NO TRAIN HAVE BEEN FOUND!");
            }
            return Ok(trains);
        }


        [HttpGet]
        [Route(ApiRoutes.Train.GetByName)]
        public async Task<IActionResult> GetTrainByName(string name)
        {
            try
            {
                var train = await _trainService.GetTrainByNameAsync(name);
                return Ok(train);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route(ApiRoutes.Train.GetById)]
        public async Task<IActionResult> GetTrainById(int id)
        {
            try
            {
                var train = await _trainService.GetTrainByIdAsync(id);
                return Ok(train);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        [Route(ApiRoutes.Train.Create)]
        public async Task<IActionResult> CreateTrain(CreateTrainRequest dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                try
                {
                    var createdTrain = await _trainService.AddTrainAsync(dto);
                    return Ok(createdTrain);
                }
                catch(Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
        }

        [Authorize]
        [HttpDelete]
        [Route(ApiRoutes.Train.Delete)]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid train ID");
                }

                var success = await _trainService.DeleteTrainAsync(id);
                return success ? Ok("Train deleted successfully") : NotFound("Train not found or already deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize, HttpPut]
        [Route(ApiRoutes.Train.Update)]
        public async Task<IActionResult> UpdateTrain(UpdateTrainRequest dto)
        {
            try
            {
                var success = await _trainService.UpdateTrainAsync(dto);
                return Ok("Train updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
