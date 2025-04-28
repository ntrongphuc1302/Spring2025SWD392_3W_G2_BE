using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public Task<List<Ticket>> GetAll()
        {
            var tickets = _context.Tickets.ToList();
            if (tickets == null)
            {
                throw new Exception("No tickets found");
            }
            else
            {
                return Task.FromResult(tickets);
            }
        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.TicketId == id);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }
            else
            {
                return Task.FromResult(ticket);
            }

        }

        public Task<bool> UpdateAsync(Ticket ticket)
        {
            var existingTicket = _context.Tickets.FirstOrDefault(t => t.TicketId == ticket.TicketId);
            if (existingTicket == null)
            {
                throw new Exception("Ticket not found");
            }
            else
            {
                existingTicket.UserId = ticket.UserId;
                existingTicket.TripId = ticket.TripId;
                //existingTicket.BookingTime = ticket.BookingTime;
                existingTicket.Price = ticket.Price;
                existingTicket.Status = ticket.Status;
                existingTicket.ValidTo = ticket.ValidTo;
                _context.Tickets.Update(existingTicket);
                return Task.FromResult(_context.SaveChanges() > 0);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.TicketId == id);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }
            else
            {
                _context.Tickets.Remove(ticket);
                return Task.FromResult(_context.SaveChanges() > 0);
            }
        }

        // New method to get tickets by userId with user details
        public async Task<List<Ticket>> GetTicketsByUserIdAsync(int userId)
        {
            try
            {
                // Include user data (assuming Ticket has a User navigation property)
                var tickets = await _context.Tickets
                    .Where(t => t.UserId == userId)
                    .Include(t => t.User)  // Include user information with the ticket
                    .ToListAsync();

                if (tickets == null || !tickets.Any())
                {
                    throw new Exception("No tickets found for this user.");
                }

                return tickets;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching tickets for the user.", ex);
            }
        }

        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            try
            {
                var ticket = await _context.Tickets
                    .Where(t => t.TicketId == ticketId)
                    .Include(t => t.User) // Include user information with the ticket
                    .FirstOrDefaultAsync();

                if (ticket == null)
                {
                    throw new Exception("Ticket not found");
                }

                return ticket;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching ticket by ID.", ex);
            }
        }
    }

}
