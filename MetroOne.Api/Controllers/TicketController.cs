using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Constants;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }


    [Authorize]
    [HttpGet]
    [Route(ApiRoutes.Ticket.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [Authorize]
    [HttpGet]
    [Route(ApiRoutes.Ticket.GetById)]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null)
                return NotFound(new { message = "Ticket not found" });
            return Ok(ticket);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [Authorize]
    [HttpPut]
    [Route(ApiRoutes.Ticket.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateTicketRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _ticketService.UpdateTicketAsync(request);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpPost]
    [Route(ApiRoutes.Ticket.Create)]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateTicketRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        { 
            var result = await _ticketService.CreateTicketAsync(request);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    //[Authorize]
    [HttpDelete]
    [Route(ApiRoutes.Ticket.Delete)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _ticketService.DeleteTicketAsync(id);
            if (!result)
                return NotFound(new { message = "Ticket not found" });
            return Ok(new { message = "Ticket deleted successfully" });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    //[Authorize]
    [HttpGet]
    [Route("api/tickets/details/user")]
    public async Task<IActionResult> GetTicketDetailsByUserId(int userId)
    {
        try
        {
            // Fetch the tickets from the service
            var tickets = await _ticketService.GetTicketsByUserIdAsync(userId);

            if (tickets == null || !tickets.Any())
            {
                return NotFound(new { message = "No tickets found for the specified user" });
            }

            // Combine the data into the response DTO
            var ticketDetails = tickets.Select(ticket => new TicketDetailResponse
            {
                TicketId = ticket.TicketId,
                TicketStatus = ticket.Status,
                Price = ticket.Price,
                BookingTime = ticket.BookingTime,
                ValidTo = ticket.ValidTo,
                UserFullName = ticket.User?.FullName,
                UserEmail = ticket.User?.Email
            }).ToList();

            return Ok(ticketDetails);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    //[Authorize]
    [HttpGet]
    [Route("api/tickets/details/{ticketId}")]
    public async Task<IActionResult> GetTicketDetailsByTicketId(int ticketId)
    {
        try
        {
            // Fetch the ticket from the service
            var ticket = await _ticketService.GetTicketByIdAsync(ticketId);

            if (ticket == null)
            {
                return NotFound(new { message = "Ticket not found" });
            }

            // Combine the data into a response DTO (you can modify this based on what you need)
            var ticketDetail = new TicketDetailWithUserResponse
            {
                TicketId = ticket.TicketId,
                TicketStatus = ticket.Status,
                Price = (decimal)ticket.Price,
                BookingTime = (DateTime)ticket.BookingTime,
                ValidTo = (DateTime)ticket.ValidTo,
                UserFullName = ticket.User?.FullName,
                UserEmail = ticket.User?.Email
            };

            return Ok(ticketDetail);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

}
