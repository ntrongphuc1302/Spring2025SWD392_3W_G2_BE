using MetroOne.DAL.Models;
using MetroOne.DAL;
using MetroOne.DAL.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MetroOne.DTO.Responses;
using static MetroOne.DTO.Constants.ApiRoutes;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MetroonedbContext _context;

        public UserRepository(MetroonedbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUserAsync(User dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null) return false;

            if (!string.IsNullOrWhiteSpace(dto.FullName)) user.FullName = dto.FullName;
            if (!string.IsNullOrWhiteSpace(dto.Phone)) user.Phone = dto.Phone;
            if (!string.IsNullOrWhiteSpace(dto.Role)) user.Role = dto.Role;
            if (!string.IsNullOrWhiteSpace(dto.Status)) user.Status = dto.Status;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllActiveUsersAsync()
        {
            return await _context.Users
                .Where(u => u.Status != "Deleted")
                .ToListAsync();
        }

        public async Task<bool> HardDeleteUserAsync(int userId)
        {
            var user = await _context.Users
                .Include(u => u.Tickets)
                    .ThenInclude(t => t.PaymentStatus)
                .Include(u => u.Passes)
                .FirstOrDefaultAsync(u => u.UserId == userId && u.Status == "Deleted");

            if (user == null)
                return false;

            // 1. Delete payment statuses
            foreach (var ticket in user.Tickets)
            {
                if (ticket.PaymentStatus != null)
                {
                    _context.PaymentStatuses.Remove(ticket.PaymentStatus);
                }
            }

            // 2. Delete tickets
            _context.Tickets.RemoveRange(user.Tickets);

            // 3. Delete passes
            _context.Passes.RemoveRange(user.Passes);

            // 4. Finally, delete the user
            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return true;

        }
    }

}
