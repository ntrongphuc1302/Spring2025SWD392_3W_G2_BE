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
            var stationCode = dto.StationName?.Replace(" ", "");

            var station = new Station
            {
                StationName = dto.StationName,
                StationCode = stationCode,
                Location = dto.Location,
                OrderInRoute = dto.OrderInRoute
            };

            await _unitOfWork.Stations.CreateStationAsync(station);
            await _unitOfWork.SaveAsync();

            return new CreateStationRespone
            {
                StationName = station.StationName,
                StationCode = station.StationCode,
                Location = station.Location,
                OrderInRoute = station.OrderInRoute
            };
        }


        public Task<bool> DeleteStationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllStationRespone>> GetAllStationAsync()
        {
            var stations = await _unitOfWork.Stations.GetAllStationAsync();
            return stations.Select(s => new GetAllStationRespone
            {
                StationId = s.StationId, 
                StationName = s.StationName,
                StationCode = s.StationCode,
                Location = s.Location,
                OrderInRoute = s.OrderInRoute
            }).ToList();
        }

        public Task<Station> GetStationByNameAsync(string StationName)
        {
            throw new NotImplementedException();
        }

        public Task<Station> GetTrainById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStationAsync(UpdateStationRequest dto)
        {
            throw new NotImplementedException();
        }
    }
}
