using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface IRouteService
    {
        Task<CreateRouteResponse> CreateRouteAsync(CreateRouteRequest request);
        Task<bool> UpdateRouteAsync(UpdateRouteRequest request);
        Task<bool> DeleteRouteAsync(int routeId);
        Task<List<GetRouteResponse>> GetAllRoutesAsync();
        Task<GetRouteResponse> GetRouteByIdAsync(int routeId);
    }
}
