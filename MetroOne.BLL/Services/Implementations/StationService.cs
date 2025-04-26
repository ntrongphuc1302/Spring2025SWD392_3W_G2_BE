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
using static MetroOne.DTO.Constants.ApiRoutes;

namespace MetroOne.BLL.Services.Implementations
{
    public class StationService : IStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateStationRespone> AddStationAsync(CreateStationRequest dto)
        {
            // Generate station code from name
            var station = new Station
            {
                StationName = dto.StationName,
                LocationId = dto.LocationId,
            };

            if (await _unitOfWork.Stations.HasStationExistAsync(dto.StationName))
            {
                throw new Exception("Station name already existed!");
            }
            else
            {
                await _unitOfWork.Stations.CreateStationAsync(station);
                await _unitOfWork.SaveAsync();

                // ✅ Lấy LocationName dựa vào LocationId
                var location = await _unitOfWork.Locations.GetLocationByIdAsync(dto.LocationId);

                return new CreateStationRespone
                {
                    StationId = station.StationId,
                    StationName = station.StationName,
                    LocationName = location?.LocationName    // Lấy tên Location
                };
            }
        }



        public async Task<bool> DeleteStationAsync(int id)
        {
            var station = await _unitOfWork.Stations.GetStationByIdAsync(id);
            if(station != null)
            {
                await _unitOfWork.Stations.DeleteStationAsync(station.StationId);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                throw new Exception("Station not found");
            }
        }

        public async Task<List<GetAllStationRespone>> GetAllStationAsync()
        {
            var stations = await _unitOfWork.Stations.GetAllStationAsync();
            return stations.Select(s => new GetAllStationRespone
            {
                StationId = s.StationId, 
                StationName = s.StationName,
                LocationName = s.Location?.LocationName
                //StationCode = s.StationCode,
                //Location = s.Location,
                //OrderInRoute = s.OrderInRoute
            }).ToList();
        }

        public async Task<Station> GetStationByNameAsync(string StationName)
        {
            var station = await _unitOfWork.Stations.GetStationByNameAsync(StationName);
            if(station == null)
            {
                throw new Exception("Station not found!");
            }
            return station;
        }

        public async Task<Station> GetStationByIdAsync(int id)
        {
            var station = await _unitOfWork.Stations.GetStationByIdAsync(id);
            if (station == null)
            {
                throw new Exception("Station not found!");
            }
            return station;
        }

        public async Task<bool> UpdateStationAsync(UpdateStationRequest dto)
        {
            var station = await _unitOfWork.Stations.GetStationByIdAsync(dto.StationId);
            if (station == null)
                throw new Exception("Station not found!");

            // Only update fields that are not null
            if (!string.IsNullOrWhiteSpace(dto.StationName))
            {
                if (await _unitOfWork.Stations.HasStationExistAsync(dto.StationName))
                {
                    throw new Exception($"Station name already existed!");
                }
                station.StationName = dto.StationName;
            }

            if (dto.LocationId.HasValue && dto.LocationId > 0)
                station.LocationId = dto.LocationId.Value;

            var result = await _unitOfWork.Stations.UpdateStationAsync(station);
            if (result)
            {
                await _unitOfWork.SaveAsync();
                return true;
            }

            return false;
        }

    }
}
