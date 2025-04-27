using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class RouteRepository : IRouteRepository
    {
        private readonly MetroonedbContext _context;
        public RouteRepository(MetroonedbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(Route route)
        {
            await _context.Routes.AddAsync(route);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Route> GetByIdAsync(int routeId)
        {
            return await _context.Routes.FindAsync(routeId);
        }
        public async Task<List<Route>> GetAllAsync()
        {
            return await _context.Routes.ToListAsync();
        }
        public async Task<bool> UpdateAsync(Route route)
        {
            _context.Routes.Update(route);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(int routeId)
        {
            var route = await GetByIdAsync(routeId);
            if (route == null) return false;
            _context.Routes.Remove(route);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
