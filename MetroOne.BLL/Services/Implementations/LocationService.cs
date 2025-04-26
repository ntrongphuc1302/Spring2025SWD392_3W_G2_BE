using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;

namespace MetroOne.BLL.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateLocationRespone> CreateLocationAsync(CreateLocationRequest dto)
        {
            var location = new Location
            {
                LocationName = dto.LocationName,
            };

            if (await _unitOfWork.Locations.HasLocationExistAsync(dto.LocationName))
            {
                throw new Exception("Location name already existed!");
            }

            await _unitOfWork.Locations.CreateLocationAsync(location);
            await _unitOfWork.SaveAsync();

            return new CreateLocationRespone
            {
                LocationId = location.LocationId, // <<< Lấy id sau khi database generate
                LocationName = location.LocationName,
            };
        }

        public async Task<bool> DeleteLocation(int id)
        {
            var location = await _unitOfWork.Locations.GetLocationByIdAsync(id);
            if (location != null)
            {
                await _unitOfWork.Locations.DeleteLocationAsync(location.LocationId);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                throw new Exception("Location not found");
            }
        }

        public async Task<List<GetAllLocationResponse>> GetAllLocationsAsync()
        {
            var locations = await _unitOfWork.Locations.GetAllLocationsAsync();
            return locations.Select(l => new GetAllLocationResponse
            {
                LocationId= l.LocationId,
                LocationName = l.LocationName,
            }).ToList();
        }

        public async Task<Location> GetLocationByIdAsync(int id)
        {
            var location = await _unitOfWork.Locations.GetLocationByIdAsync(id);
            if(location == null)
            {
                throw new Exception("Location not found!");
            }
            return location;
        }

        public async Task<Location> GetLocationByNameAsync(string name)
        {
            {
                var location = await _unitOfWork.Locations.GetLocationByNameAsync(name);
                if (location == null)
                {
                    throw new Exception("Location not found!");
                }
                return location;
            }
        }
    }
}
