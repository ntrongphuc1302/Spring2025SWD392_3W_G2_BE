using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAll();
        Task<Ticket> GetByIdAsync(int id);
        Task<bool> CreateAsync(Ticket ticket);
        Task<bool> UpdateAsync(Ticket ticket);
        Task<bool> DeleteAsync(int id);
    }
}
