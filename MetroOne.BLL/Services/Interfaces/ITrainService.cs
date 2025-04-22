using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface ITrainService
    {
        Task<List<GetAllTrainResponse>> GetAllTrainsAsync();
        Task<Train> GetTrainByIdAsync(int id);
        Task<Train> GetTrainByNameAsync(string name);
        Task<CreateTrainRespone> AddTrainAsync(CreateTrainRequest dto);
        Task<bool> UpdateTrainAsync(Train train);
        Task<bool> DeleteTrainAsync(int id);
    }
}
