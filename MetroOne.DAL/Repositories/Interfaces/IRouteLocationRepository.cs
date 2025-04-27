using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface IRouteLocationRepository
    {
        Task<bool> CreateAsync(RouteLocation routeLocation);
        Task<bool> UpdateAsync(RouteLocation routeLocation);
        Task<bool> DeleteAsync(int id);
        Task<List<RouteLocation>> GetAll();
        Task<RouteLocation> GetByIdAsync(int id);
        Task<RouteLocation?> GetByLocationIdAsync(int locationId);
    }
}

