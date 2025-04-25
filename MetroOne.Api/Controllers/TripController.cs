using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Constants;
using MetroOne.DTO.Requests;
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
        [HttpPost]
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

        // POST: TripController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
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

        // GET: TripController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

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

        // GET: TripController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TripController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
