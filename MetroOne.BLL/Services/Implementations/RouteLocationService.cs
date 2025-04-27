using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;

namespace MetroOne.BLL.Services.Implementations
{
    public class RouteLocationService : IRouteLocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouteLocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CreateRouteLoacationResponse> CreateAsync(CreateRouteLoacationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RouteLocation>> GetAll()
        {
            var routeLocations = _unitOfWork.RouteLocations.GetAll();
            if (routeLocations == null)
            {
                throw new Exception("No route locations found");
            }
            else
            {
                throw new Exception("Route locations found");
            }
        }

        public Task<RouteLocation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(UpdateRouteLoacationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
