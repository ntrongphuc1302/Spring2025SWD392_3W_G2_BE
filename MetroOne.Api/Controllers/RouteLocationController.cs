using MetroOne.BLL.Services.Implementations;
using MetroOne.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MetroOne.DTO.Constants;
using MetroOne.DTO.Requests;
namespace MetroOne.API.Controllers
{
    [ApiController]
    public class RouteLocationController : ControllerBase
    {
        private readonly IRouteLocationService _routeLocationService;

        public RouteLocationController(IRouteLocationService routeLocationService)
        {
            _routeLocationService = routeLocationService;
        }

        [HttpGet]
        [Route(ApiRoutes.RouteLocation.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var routeLocations = await _routeLocationService.GetAll();
                if (routeLocations == null)
                {
                    return NotFound(new { message = "No avlaable reoute location" });
                }
                else
                {
                    return Ok(routeLocations);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route(ApiRoutes.RouteLocation.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var routeLocation = await _routeLocationService.GetByIdAsync(id);
                if (routeLocation == null)
                {
                    return NotFound(new { message = "Route location not found" });
                }
                else
                {
                    return Ok(routeLocation);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route(ApiRoutes.RouteLocation.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRouteLoacationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var routeLocation = await _routeLocationService.CreateAsync(request);
                return Ok(routeLocation);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route(ApiRoutes.RouteLocation.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _routeLocationService.DeleteAsync(id);
                if (result)
                {
                    return Ok(new { message = "Route location deleted successfully" });
                }
                else
                {
                    return NotFound(new { message = "Route location not found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut]
        [Route(ApiRoutes.RouteLocation.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateRouteLoacationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedRouteLocation = await _routeLocationService.UpdateAsync(request);
                return Ok(updatedRouteLocation);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
