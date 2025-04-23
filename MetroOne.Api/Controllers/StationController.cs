using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Constants;
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
        public async Task<ActionResult> Index()
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

        //// GET: StationController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: StationController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: StationController/Create
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

        //// GET: StationController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: StationController/Edit/5
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

        //// GET: StationController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: StationController/Delete/5
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
