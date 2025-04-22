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
        Task<Station?> GetStationById(int id);
        Task<Boolean> HasStationAsync(int id);
    }
}
