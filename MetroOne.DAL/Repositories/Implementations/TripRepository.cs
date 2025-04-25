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
    public class TripRepository : ITripRepository
    {
        private readonly MetroonedbContext _context;
        public TripRepository(MetroonedbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTripsAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteTripsAsync(int id)
        {
           var trip = await _context.Trips.FindAsync(id);
            if(trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Trip>> GetAllTripAsync()
        {
            return await _context.Trips.ToListAsync();
        }

        public async Task<Trip> GetByTripIdAsync(int id)
        {
            return await _context.Trips.FindAsync(id);
        }

        public async Task<bool> UpdateTripsAsync(Trip dto)
        {
            var trip = await _context.Trips.FindAsync(dto.TrainId);
            if(trip != null)
            {
                _context.Entry(dto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
