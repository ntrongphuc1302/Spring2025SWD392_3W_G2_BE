using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;
using MetroOne.DTO.Requests;
using Microsoft.EntityFrameworkCore;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly MetroonedbContext _context;
        public LocationRepository(MetroonedbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteLocationAsync(int LocationId)
        {
            var location = await _context.Locations.FindAsync(LocationId);
            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Location>> GetAllLocationsAsync()
        {
           return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<Location> GetLocationByNameAsync(string name)
        {
            return await _context.Locations.FirstOrDefaultAsync(l => l.LocationName == name);
        }

        public async Task<bool> HasLocationExistAsync(string LocationName)
        {
            return await _context.Locations.AnyAsync(l => l.LocationName == LocationName);
        }
    }
}
