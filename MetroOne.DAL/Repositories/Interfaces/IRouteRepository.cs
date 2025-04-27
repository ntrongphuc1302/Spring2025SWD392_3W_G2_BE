using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface IRouteRepository
    {   
        Task<bool> CreateAsync(Route route);
        Task<Route> GetByIdAsync(int routeId);
        Task<List<Route>> GetAllAsync();
        Task<bool> UpdateAsync(Route route);
        Task<bool> DeleteAsync(int routeId);

    }
}
