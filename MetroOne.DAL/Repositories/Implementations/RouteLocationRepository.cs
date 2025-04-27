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
        public Task<bool> CreateAsync(RouteLocation routeLocation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<bool> UpdateAsync(RouteLocation routeLocation)
        {
            throw new NotImplementedException();
        }
    }
}
