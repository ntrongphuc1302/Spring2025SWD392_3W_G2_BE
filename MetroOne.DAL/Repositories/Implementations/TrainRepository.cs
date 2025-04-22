using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static MetroOne.DTO.Constants.ApiRoutes;
using Train = MetroOne.DAL.Models.Train;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class TrainRepository : ITrainRepository
    {
        private readonly MetroonedbContext _context;
        public TrainRepository(MetroonedbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddTrainAsync(Train train)
        {
            _context.Trains.Add(train);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<bool> DeleteTrainAsync(int TrainID)
        {
            var train = await _context.Trains.FindAsync(TrainID);
            if (train != null)
            {
                _context.Trains.Remove(train);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
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

        public async Task<List<Train?>> GetAllTrainsAsync()
        {
            return await _context.Trains.ToListAsync();
        }

        public async Task<bool> UpdateTrainAsync(Train dto)
        {
            var train = await _context.Trains.FindAsync(dto.TrainId);
            if(train != null) { 
            _context.Entry(dto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> IsTrainNameExistsAsync(string TrainName)
        {
            return await _context.Trains.AnyAsync(t =>t.TrainName == TrainName);
        }
    }
}
