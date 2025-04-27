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
using Microsoft.AspNetCore.Http.HttpResults;

namespace MetroOne.BLL.Services.Implementations
{
    public class RouteLocationService : IRouteLocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouteLocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateRouteLoacationResponse> CreateAsync(CreateRouteLoacationRequest request)
        {
            var existingRouteLocation = await _unitOfWork.RouteLocations.GetByLocationIdAsync(request.LocationId);
            if (existingRouteLocation != null)
            {
                throw new Exception($"RouteLocation for LocationID {request.LocationId} already exists.");
            }
            var location = await _unitOfWork.Locations.GetLocationByIdAsync(request.LocationId);
            if (location == null)
            {
                throw new Exception($"Location with ID {request.LocationId} not found.");
            }

            var routeLocation = new RouteLocation
            {
                LocationId = request.LocationId,
            };

            var success = await _unitOfWork.RouteLocations.CreateAsync(routeLocation);
            if (!success)
            {
                throw new Exception("Failed to create route location");
            }

            return new CreateRouteLoacationResponse
            {
                RouteLocationId = routeLocation.RouteLocationId,
                LocationId = routeLocation.LocationId,
            };
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _unitOfWork.RouteLocations.DeleteAsync(id);
            if (!result)
            {
                throw new Exception("Failed to delete route location");
            }
            return true;
        }

        public async Task<List<GetAllRouteLocationResponse>> GetAll()
        {
            var routeLocations = await _unitOfWork.RouteLocations.GetAll();
            var routeLocationResponses = routeLocations.Select(routeLocation => new GetAllRouteLocationResponse
            {
                RouteLocationId = routeLocation.RouteLocationId,
                LocationId = routeLocation.LocationId,
            }).ToList();
            return routeLocationResponses;
        }

        public async Task<GetAllRouteLocationResponse> GetByIdAsync(int id)
        {
            var routeLocation = await _unitOfWork.RouteLocations.GetByIdAsync(id);
            if (routeLocation == null)
            {
                throw new Exception("Route location not found");
            }
            else
            {
                return new GetAllRouteLocationResponse
                {
                    RouteLocationId = routeLocation.RouteLocationId,
                    LocationId = routeLocation.LocationId,
                };
            }
        }

        public async Task<bool> UpdateAsync(UpdateRouteLoacationRequest request)
        {
            var routeLocation = await _unitOfWork.RouteLocations.GetByIdAsync(request.RouteLocationId);
            if (routeLocation == null)
            {
                throw new Exception($"RouteLocation with ID {request.RouteLocationId} not found.");
            }

            var location = await _unitOfWork.Locations.GetLocationByIdAsync(request.LocationId);
            if (location == null)
            {
                throw new Exception($"Location with ID {request.LocationId} not found.");
            }

            // Check if trying to assign to an already existing RouteLocation (prevent duplicate LocationId)
            var existingRouteLocation = await _unitOfWork.RouteLocations.GetByLocationIdAsync(request.LocationId);
            if (existingRouteLocation != null && existingRouteLocation.RouteLocationId != request.RouteLocationId)
            {
                throw new Exception($"LocationID {request.LocationId} is already assigned to another RouteLocation.");
            }

            // Update fields
            routeLocation.LocationId = request.LocationId;

            var success = await _unitOfWork.RouteLocations.UpdateAsync(routeLocation);
            if (!success)
            {
                throw new Exception("Failed to update RouteLocation.");
            }

            return true;
        }

    }
}
