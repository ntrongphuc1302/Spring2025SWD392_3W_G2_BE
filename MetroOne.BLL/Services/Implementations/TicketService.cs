using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.UnitOfWork;

namespace MetroOne.BLL.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateTicketResponse> CreateTicketAsync(CreateTicketRequest request)
        {
            var ticket = new Ticket
            {
                UserId = request.UserId,
                TripId = request.TripId,
                StartStationId = request.StartStationId,
                EndStationId = request.EndStationId,
                Price = request.Price,
                Status = request.Status ?? "Pending",
                Qrcode = request.QRCode
            };

            var success = await _unitOfWork.Tickets.CreateAsync(ticket);
            if (!success)
                throw new Exception("Failed to create ticket");

            return new CreateTicketResponse
            {
                TicketId = ticket.TicketId,
                UserId = ticket.UserId,
                TripId = ticket.TripId,
                StartStationId = ticket.StartStationId,
                EndStationId = ticket.EndStationId,
                BookingTime = ticket.BookingTime,
                Price = ticket.Price,
                Status = ticket.Status,
                QRCode = ticket.Qrcode
            };
        }
    }

}
