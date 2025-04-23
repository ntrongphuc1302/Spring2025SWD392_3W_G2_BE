using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface IStationRepository
    {
        Task<List<Station?>> GetAllStationAsync();
        Task<Station?> GetStationByIdAsync(int id);
        Task<Station?> GetStationByNameAsync(string StationName);
        Task<Boolean> HasStationExistAsync(int StationId);
        Task<bool> CreateStationAsync(Station station);
        Task<bool> UpdateStationAsync(Station dto);
        Task<bool> DeleteStationAsync(int id);
    }
}
