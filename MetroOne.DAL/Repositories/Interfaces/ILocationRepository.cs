using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DTO.Requests;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocationsAsync();
        Task<Location> GetLocationByIdAsync(int id);
        Task<bool> HasLocationExistAsync(string LocationName);
        Task<Location> GetLocationByNameAsync(string name);
        Task<bool> CreateLocationAsync(Location location);
        Task<bool> DeleteLocationAsync(int LocationId);

    }
}
