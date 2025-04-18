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
        Task<IEnumerable<Train?>> getTrainsAsync();
        Task<Train?> getTrainByNameAsync(string TrainName);
        Task AddTrainAsync(Train train);
        Task UpdateTrainAsync(Train train);
        Task DeleteTrainAsync(int TrainID);
        

    }
}
