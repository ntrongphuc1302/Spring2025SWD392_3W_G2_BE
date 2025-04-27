using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Constants;
using MetroOne.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MetroOne.DTO.Responses;

namespace MetroOne.API.Controllers
{
    [ApiController]
    public class RouteController :ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [Authorize]
        [HttpGet]
        [Route(ApiRoutes.Route.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var routes = await _routeService.GetAllRoutesAsync();
                return Ok(routes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpGet]
        [Route(ApiRoutes.Route.GetById)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var route = await _routeService.GetRouteByIdAsync(id);
                if (route == null)
                    return NotFound(new { message = "Route not found" });
                return Ok(route);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPost]
        [Route(ApiRoutes.Route.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRouteRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var route = await _routeService.CreateRouteAsync(request);
                return Ok(route);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpPut]
        [Route(ApiRoutes.Route.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateRouteRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _routeService.UpdateRouteAsync(request);
                if (!result)
                    return NotFound(new { message = "Route not found" });
                return Ok(new { message = "Route updated successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route(ApiRoutes.Route.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _routeService.DeleteRouteAsync(id);
                if (!result)
                    return NotFound(new { message = "Route not found" });
                return Ok(new { message = "Route deleted successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
