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
    public class TrainRepository : ITrainRepository
    {
        private readonly MetroonedbContext _context;
        public TrainRepository(MetroonedbContext context)
        {
            _context = context;
        }

        public async Task AddTrainAsync(Train train)
        {
            _context.Trains.Add(train);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainAsync(int TrainID)
        {
            var train = await _context.Trains.FindAsync(TrainID);
            if (train != null)
            {
                _context.Trains.Remove(train);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Train?> GetTrainByIdAsync(int id)
        {
            return await _context.Trains.FindAsync(id);
        }

        public async Task<Train?> GetTrainByNameAsync(string trainName)
        {
            return await _context.Trains.FirstOrDefaultAsync(t => t.TrainName == trainName);
        }

        public async Task<IEnumerable<Train?>> GetAllTrainsAsync()
        {
            return await _context.Trains.ToListAsync();
        }

        public async Task UpdateTrainAsync(Train train)
        {
            _context.Entry(train).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
