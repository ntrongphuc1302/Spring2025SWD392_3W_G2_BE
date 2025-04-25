using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Constants;
using MetroOne.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetroOne.API.Controllers
{
    [ApiController]
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        // GET: TripController
        [HttpGet]
        [Route(ApiRoutes.Trip.GetAll)]
        public async Task<IActionResult> Index()
        {
            var trips = await _tripService.GetAllTripsAsync();
            if (trips == null)
            {
                return NotFound("No Trip have been found!");
            }
            return Ok(trips);
        }


        // GET: TripController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // POST: TripController/Create
        [HttpPost, Authorize]
        [Route(ApiRoutes.Trip.Create)]
        public async Task<IActionResult> Create(CreateTripRequest dto)
        {
            try
            {
                var createTrip = await _tripService.CreateTripAsync(dto);
                return Ok(createTrip);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: TripController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //Delete: TripController/Delete/
        [HttpDelete, Authorize]
        [Route(ApiRoutes.Trip.Delete)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await _tripService.DeleteTripAsync(id);
                return success ? Ok("Trip deleted successfully") : NotFound("Trip not found or already deleted");

            }
            catch(Exception ex) 
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
