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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: LocationController
        [HttpGet]
        [Route(ApiRoutes.Locations.GetAll)]
        public async Task<IActionResult> Index()
        {
            var locations = await _locationService.GetAllLocationsAsync();
            if (locations == null)
            {
                return NotFound("No location was found!");
            }
            else
            {
                return Ok(locations);
            }
        }

        // POST: StationController/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route(ApiRoutes.Locations.Create)]
        public async Task<IActionResult> CreateLocation(CreateLocationRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createLocation = await _locationService.CreateLocationAsync(dto);
                return Ok(createLocation);
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new { message = errorMessage });
            }

        }

        [HttpGet]
        [Route(ApiRoutes.Locations.GetByName)]
        public async Task<IActionResult> GetLocationByName(string name)
        {
            try
            {
                var location = await _locationService.GetLocationByNameAsync(name);
                return Ok(location);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route(ApiRoutes.Locations.GetById)]
        public async Task<IActionResult> GetLocationById(int id)
        {
            try
            {
                var location = await _locationService.GetLocationByIdAsync(id);
                return Ok(location);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // Delete: StationController/Delete
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route(ApiRoutes.Locations.Delete)]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Invalid train ID");
                }
                var success = await _locationService.DeleteLocation(id);
                return success ? Ok("Location deleted successfully") : NotFound("Location not found or already deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
