using Microsoft.AspNetCore.Mvc;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Constants;
using MetroOne.DTO.Requests;
using MetroOne.DAL.Models;
using System.Threading.Tasks;
using System;
using Azure.Core;
using MetroOne.BLL.Services.Implementations;
using MetroOne.DTO.Responses;

namespace MetroOne.API.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: PaymentController
        [HttpGet]
        [Route(ApiRoutes.Payment.GetAll)]
        public async Task<IActionResult> Index()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            if (payments == null)
            {
                return NotFound("No payment was found!");
            }
            else
            {
                return Ok(payments);
            }
        }
        // GET: PaymentController/Details/5
        [HttpGet]
        [Route(ApiRoutes.Payment.GetById)]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByIdAsync(id);
                return Ok(payment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST: PaymentController/Create
        [HttpPost]
        [Route(ApiRoutes.Payment.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePaymentRequest paymentRequest)
        {
            try
            {
                var result = await _paymentService.AddPaymentAsync(paymentRequest);
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: PaymentController/Edit/5
        [HttpPut]
        [Route(ApiRoutes.Payment.Update)]

        public async Task<IActionResult> Edit([FromBody] UpdatePaymentRequest paymentRequest)
        {
            try
            {
                var result = await _paymentService.UpdatePaymentAsync(paymentRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
