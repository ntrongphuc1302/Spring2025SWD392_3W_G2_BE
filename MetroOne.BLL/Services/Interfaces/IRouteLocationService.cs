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
    public interface IRouteLocationService
    {
        Task<CreateRouteLoacationResponse> CreateAsync(CreateRouteLoacationRequest request);
        Task<bool> UpdateAsync(UpdateRouteLoacationRequest request);
        Task<bool> DeleteAsync(int id);
        Task<List<RouteLocation>> GetAll();
        Task<RouteLocation> GetByIdAsync(int id);
        //Task<List <RouteLocation>> GetByLocationIdAsync(int locationId);
    }
}
