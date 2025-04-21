using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface ITrainService
    {
        Task<List<Train>> GetAllTrainsAsync();
        Task<Train> GetTrainByIdAsync(int id);
        Task<bool> AddTrainAsync(Train train);
        Task<bool> UpdateTrainAsync(Train train);
        Task<bool> DeleteTrainAsync(int id);
    }
}
