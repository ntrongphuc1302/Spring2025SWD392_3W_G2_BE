using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL;
using MetroOne.DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetroOne.API.Controllers.TrainController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly MetroonedbContext _context;
        private readonly ILogger<TrainController> _logger;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public TrainController(IUnitOfWork unitOfWork, MetroonedbContext context, ILogger<TrainController> logger, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
            _authService = authService;
        }

        // GET: TrainController
        [HttpGet("getTrain")]
        public async Task<IActionResult> Index()
        {
            var trains = await _unitOfWork.TrainRepository.getTrainsAsync();
            if(trains == null)
            {
                return NotFound("NO TRAIN HAVE BEEN FOUND!");
            }
            return Ok(trains);
        }

        [HttpGet("api/[controller]")]
        // GET: TrainController/Details/5
        public async Task<ActionResult> GetTrainByName(string trainName)
        {
            var train = await _unitOfWork.TrainRepository.getTrainByNameAsync(trainName);
            if (train == null)
            {
                return NotFound("TRAIN NOT FOUND OR DOESN'T EXIST!");
            }
            return Ok(train);
        }

        //// GET: TrainController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TrainController/Create
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

        //// GET: TrainController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TrainController/Edit/5
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

        //// GET: TrainController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TrainController/Delete/5
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
