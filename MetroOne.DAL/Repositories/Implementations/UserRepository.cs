using MetroOne.DAL.Models;
using MetroOne.DAL;
using MetroOne.DAL.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MetroonedbContext _context;

        public UserRepository(MetroonedbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }

}
