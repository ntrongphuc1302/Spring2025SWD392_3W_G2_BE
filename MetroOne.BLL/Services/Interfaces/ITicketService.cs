using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface ITicketService
    {
        Task<CreateTicketResponse> CreateTicketAsync(CreateTicketRequest request);
        Task<List<GetAllTicketResponse>> GetAllTicketsAsync();
        Task<GetAllTicketResponse> GetByIdAsync(int id);
        Task<bool> UpdateTicketAsync(UpdateTicketRequest request);
        Task<bool> DeleteTicketAsync(int id);
        Task<List<DAL.Models.Ticket>> GetTicketsByUserIdAsync(int userId);
        Task<DAL.Models.Ticket> GetTicketByIdAsync(int ticketId);
    }
}
