using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface ITrainRepository
    {
        Task<List<Train?>> GetAllTrainsAsync();
        Task<Train?> GetTrainByNameAsync(string TrainName);
        Task<Boolean> IsTrainNameExistsAsync(string TrainName);
        Task<Train?> GetTrainByIdAsync(int id);
        Task<bool> AddTrainAsync(Train train);
        Task<bool> UpdateTrainAsync(Train dto);
        Task<bool> DeleteTrainAsync(int TrainID);
        

    }
}
