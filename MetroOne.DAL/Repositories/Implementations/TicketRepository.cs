using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class TicketRepository : ITicketRepository
    {
        private readonly MetroonedbContext _context;

        public TicketRepository(MetroonedbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
