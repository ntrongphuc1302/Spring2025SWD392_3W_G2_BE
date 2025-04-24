using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface ITripRepository
    {
        Task<bool> CreateTripsAsync(Trip trip);
        Task<bool> UpdateTripsAsync(Trip trip);
        Task<bool> DeleteTripsAsync(int id);
    }
}
