using Microsoft.AspNetCore.Mvc;
using MetroOne.DAL;
using Microsoft.EntityFrameworkCore;
using MetroOne.DTO.Constants;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Requests;
using MetroOne.DAL.Models;
using MetroOne.DTO.Responses;

namespace MetroOne.API.Controllers
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
            if (trains == null)
            {
                return NotFound("NO TRAIN HAVE BEEN FOUND!");
            }
            return Ok(trains);
        }

        [HttpGet("api/[controller]")]
        // GET: TrainController/Details/
        public async Task<ActionResult> GetTrainByName(string trainName)
        {
            var train = await _unitOfWork.TrainRepository.getTrainByNameAsync(trainName);
            if (train == null)
            {
                return NotFound("TRAIN NOT FOUND OR DOESN'T EXIST!");
            }
            return Ok(train);
        }

        [HttpPost("/api/[controller]")]
        public async Task<ActionResult<CreateTrainRespone>> CreateTrain([FromBody] CreateTrainRequest dto)
        {
            if (dto == null)
                return BadRequest("Invalid train data.");

            var train = new Train
            {
                TrainName = dto.TrainName,
                StartStationId = dto.StartStationId,
                EndStationId = dto.EndStationId,
                Capacity = dto.Capacity,
                EstimatedTime = dto.EstimatedTime
            };

            await _unitOfWork.TrainRepository.AddTrainAsync(train);
            await _unitOfWork.SaveAsync();

            var response = new CreateTrainRespone
            {
                TrainName = train.TrainName!,
                StartStationId = train.StartStationId,
                EndStationId = train.EndStationId,
                Capacity = train.Capacity,
                EstimatedTime = train.EstimatedTime
            };

            return CreatedAtAction(nameof(GetTrainByName), new { TrainName = response.TrainName }, response);
        }


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
