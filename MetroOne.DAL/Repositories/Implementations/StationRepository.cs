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
    public class StationRepository : IStationRepository
    {
        private readonly MetroonedbContext _context;
        public StationRepository(MetroonedbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateStationAsync(Station station)
        {
            await _context.AddAsync(station);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteStationAsync(int id)
        {
           var station = await _context.Stations.FindAsync(id);
            if (station != null)
            {
                _context.Stations.Remove(station);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Station?>> GetAllStationAsync()
        {
            return await _context.Stations.ToListAsync();
        }

        public async Task<Station?> GetStationByIdAsync(int id)
        {
            return await _context.Stations.FindAsync(id);
        }

        public async Task<Station?> GetStationByNameAsync(string StationName)
        {
            return await _context.Stations.FirstOrDefaultAsync(s => s.StationName == StationName);
        }

        public async Task<bool> HasStationExistAsync(string StationName)
        {
            return await _context.Stations.AnyAsync(s => s.StationName == StationName);
        }

        public async Task<bool> UpdateStationAsync(Station dto)
        {
            var station = await _context.Stations.FindAsync(dto.StationId);
            if(station != null)
            {
                _context.Entry(dto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
