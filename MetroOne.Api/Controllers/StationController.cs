using System.Threading.Tasks;
using MetroOne.BLL.Services.Implementations;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Constants;
using MetroOne.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetroOne.API.Controllers
{
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;
        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        // GET: StationController
        [HttpGet]
        [Route(ApiRoutes.Stations.GetAll)]
        public async Task<IActionResult> Index()
        {
            var stations = await _stationService.GetAllStationAsync();
            if (stations == null)
            {
                return NotFound("No station was found!");
            }
            else
            {
                return Ok(stations);
            }
        }

        // POST: StationController/Create
        [Authorize]
        [HttpPost]
        [Route(ApiRoutes.Stations.Create)]
        public async Task<IActionResult> CreateStation(CreateStationRequest dto)
        {
            try
            {
                var createStation = await _stationService.AddStationAsync(dto);
                return Ok(createStation);
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new { message = errorMessage });
            }

        }

        [HttpGet]
        [Route(ApiRoutes.Stations.GetByName)]
        public async Task<IActionResult> GetTrainByName(string name)
        {
            try
            {
                var train = await _stationService.GetStationByNameAsync(name);
                return Ok(train);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route(ApiRoutes.Stations.GetById)]
        public async Task<IActionResult> GetStationById(int id)
        {
            try
            {
                var train = await _stationService.GetStationByIdAsync(id);
                return Ok(train);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Put: StationController/Edit
        [Authorize, HttpPut]
        [Route(ApiRoutes.Stations.Update)]
        public async Task<IActionResult> Update(UpdateStationRequest dto)
        {
            try
            {
                var success = await _stationService.UpdateStationAsync(dto);
                return Ok("Station updated successfully!");
            }
            catch(Exception ex) 
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Delete: StationController/Delete
        [Authorize]
        [HttpDelete]
        [Route(ApiRoutes.Stations.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid train ID");
                }
                var success = await _stationService.DeleteStationAsync(id);
                return success ? Ok("Station deleted successfully") : NotFound("Station not found or already deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
