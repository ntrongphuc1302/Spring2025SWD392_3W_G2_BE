using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class RouteLocationRepository : IRouteLocationRepository
    {
        private readonly MetroonedbContext _context;
        public RouteLocationRepository(MetroonedbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(RouteLocation routeLocation)
        {
            _context.RouteLocations.Add(routeLocation);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var routeLocation = await _context.RouteLocations.FindAsync(id);
            if (routeLocation == null)
            {
                throw new Exception("Route location not found");
            }
            _context.RouteLocations.Remove(routeLocation);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


        public async Task<List<RouteLocation>> GetAll()
        {
            var routeLocations = _context.RouteLocations.ToList();
            if (routeLocations == null)
            {
                throw new Exception("No route locations found");
            }
            else
            {
                return await Task.FromResult(routeLocations);
            }

        }

        public Task<RouteLocation> GetByIdAsync(int id)
        {
            var routeLocation = _context.RouteLocations
                .FirstOrDefault(r => r.RouteLocationId == id);
            if (routeLocation == null)
            {
                throw new Exception("Route location not found");
            }
            else
            {
                return Task.FromResult(routeLocation);
            }
        }

        public async Task<RouteLocation?> GetByLocationIdAsync(int locationId)
        {
            return await _context.RouteLocations.FirstOrDefaultAsync(rl => rl.LocationId == locationId);
        }

        public async Task<bool> UpdateAsync(RouteLocation routeLocation)
        {
            _context.RouteLocations.Update(routeLocation);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
