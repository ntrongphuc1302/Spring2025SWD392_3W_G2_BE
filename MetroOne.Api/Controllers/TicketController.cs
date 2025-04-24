using MetroOne.BLL.Services.Interfaces;
using MetroOne.DTO.Constants;
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

    [HttpPost]
    [Route(ApiRoutes.Ticket.Create)]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateTicketRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _ticketService.CreateTicketAsync(request);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}
