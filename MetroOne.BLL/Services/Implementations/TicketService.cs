using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;
using static MetroOne.DTO.Constants.ApiRoutes;

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
            var bookingTime = DateTime.UtcNow;
            var ticket = new DAL.Models.Ticket
            {
                UserId = request.UserId,
                TripId = request.TripId,
                BookingTime = bookingTime,
                Price = request.Price,
                Status = request.Status ?? "Active",
                ValidTo = request.ValidTo,
            };

            var success = await _unitOfWork.Tickets.CreateAsync(ticket);
            if (!success)
                throw new Exception("Failed to create ticket");

            return new CreateTicketResponse
            {
                TicketId = ticket.TicketId,
                UserId = ticket.UserId,
                TripId = ticket.TripId,
                BookingTime = ticket.BookingTime,
                Price = ticket.Price,
                Status = ticket.Status,
                ValidTo = ticket.ValidTo,
            };
        }

        public async Task<List<GetAllTicketResponse>> GetAllTicketsAsync()
        {
            var tickets = await _unitOfWork.Tickets.GetAll();

            var ticketResponses = new List<GetAllTicketResponse>();

            foreach (var ticket in tickets)
            {
                TicketId = ticket.TicketId,
                UserId = ticket.UserId,
                TripId = ticket.TripId,
                BookingTime = ticket.BookingTime,
                Price = ticket.Price,
                Status = ticket.Status,
                ValidTo = ticket.ValidTo,
            }).ToList();
            return ticketResponses;
        }


        public async Task<GetAllTicketResponse> GetByIdAsync(int id)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(id);
            var train = await _unitOfWork.Trains.GetTrainByIdAsync(id);
            if (ticket == null)
                throw new Exception("Ticket not found");

            var trip = await _unitOfWork.Trips.GetByTripIdAsync(ticket.TripId);
            var startStation = await _unitOfWork.Stations.GetStationByIdAsync(train.StartStationId);
            var endStation = await _unitOfWork.Stations.GetStationByIdAsync(train.EndStationId);

            return new GetAllTicketResponse
                {TicketId = ticket.TicketId,
                UserId = ticket.UserId,
                TripId = ticket.TripId,
                BookingTime = ticket.BookingTime,
                Price = ticket.Price,
                Status = ticket.Status,
                ValidTo = ticket.ValidTo,
            };
        }


        public async Task<bool> UpdateTicketAsync(UpdateTicketRequest request)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(request.TicketId);
            if (ticket == null)
                throw new Exception("Ticket not found");
            ticket.UserId = request.UserId;
            ticket.TripId = request.TripId;
            //ticket.BookingTime = request.BookingTime;
            ticket.Price = request.Price;
            ticket.Status = request.Status ?? "Pending";
            ticket.ValidTo = request.ValidTo;
            var success = await _unitOfWork.Tickets.UpdateAsync(ticket);
            if (!success)
                throw new Exception("Failed to update ticket");
            return true;
        }

        public async Task<bool> DeleteTicketAsync(int id)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(id);
            if (ticket == null)
                throw new Exception("Ticket not found");
            var success = await _unitOfWork.Tickets.DeleteAsync(id);
            if (!success)
                throw new Exception("Failed to delete ticket");
            return true;
        }
    }

}
