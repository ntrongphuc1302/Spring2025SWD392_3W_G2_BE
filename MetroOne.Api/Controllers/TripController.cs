//using MetroOne.BLL.Services.Implementations;
//using MetroOne.DTO.Constants;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MetroOne.API.Controllers
//{
//    [ApiController]
//    public class TripController : Controller
//    {
//        private readonly TripService _tripService;
//        public TripController(TripService tripService)
//        {
//            _tripService = tripService;
//        }
//        // GET: TripController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: TripController/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // POST: TripController/Create
//        [HttpPost]
//        [Route(ApiRoutes.Trip.Create)]
//        public Task<IActionResult> Create()
//        {
//            return null;
//        }

//        // POST: TripController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: TripController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: TripController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: TripController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: TripController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
