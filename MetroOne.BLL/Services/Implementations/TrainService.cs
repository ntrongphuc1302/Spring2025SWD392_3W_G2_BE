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
    public class TrainService : ITrainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateTrainRespone> AddTrainAsync(CreateTrainRequest dto)
        {
            var train = new Train
            {
                TrainName = dto.TrainName,
                EstimatedTime = dto.EstimatedTime,
                RouteLocationId = dto.RouteLocationId,
                Capacity = dto.Capacity,
            };
            //var routeLocation = await _unitOfWork.RouteLocations.GetRouteLocationByIdAsync(dto.RouteLocationId);
            //if (routeLocation == null)
            //{
            //    throw new Exception("RouteLocation not found!");
            //}
            if (await _unitOfWork.Trains.IsTrainNameExistsAsync(dto.TrainName))
            {
                throw new Exception("Train name already existed!");
            }
            else
            {
                await _unitOfWork.Trains.AddTrainAsync(train);
                await _unitOfWork.SaveAsync();

                return new CreateTrainRespone
                {
                    TrainName = train.TrainName,
                    EstimatedTime = train.EstimatedTime,
                    Capacity = train.Capacity,
                    //LocationName = routeLocation.Location?.LocationName
                };
            }
        }

        public async Task<bool> DeleteTrainAsync(int id)
        {
            var train = await _unitOfWork.Trains.GetTrainByIdAsync(id);
            if (train != null)
            {
                await _unitOfWork.Trains.DeleteTrainAsync(train.TrainId);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                throw new Exception("Train not found");
            }
        }

        public async Task<List<GetAllTrainResponse>> GetAllTrainsAsync()
        {
            var trains = await _unitOfWork.Trains.GetAllTrainsAsync();
            return trains.Select(t => new GetAllTrainResponse
            {
                TrainId = t.TrainId,
                TrainName = t.TrainName,
                EstimatedTime = t.EstimatedTime,
                Capacity = t.Capacity,
                LocationName = t.RouteLocation?.Location?.LocationName // Lấy tên địa điểm
            }).ToList();
        }

        public async Task<TrainResponse> GetTrainByIdAsync(int id)
        {
            var train = await _unitOfWork.Trains.GetTrainByIdAsync(id);
            if (train == null)
                throw new Exception("Train not found!");

            return new TrainResponse
            {
                TrainId = train.TrainId,
                TrainName = train.TrainName,
                EstimatedTime = train.EstimatedTime,
                Capacity = train.Capacity,
                LocationName = train.RouteLocation?.Location?.LocationName // thêm dòng này
            };
        }

        public async Task<TrainResponse> GetTrainByNameAsync(string name)
        {
            var train = await _unitOfWork.Trains.GetTrainByNameAsync(name);
            if (train == null)
                throw new Exception("Train not found!");

            //var startStation = await _unitOfWork.Stations.GetStationByIdAsync(train.StartStationId);
            //var endStation = await _unitOfWork.Stations.GetStationByIdAsync(train.EndStationId);

            return new TrainResponse
            {
                TrainId = train.TrainId,
                TrainName = train.TrainName,
                EstimatedTime = train.EstimatedTime,
                Capacity = train.Capacity,
                LocationName = train.RouteLocation?.Location?.LocationName // thêm dòng này
            };
        }

        public async Task<bool> UpdateTrainAsync(UpdateTrainRequest dto)
        {
            var train = await _unitOfWork.Trains.GetTrainByIdAsync(dto.TrainId);
            if (train == null)
                throw new Exception("Train not found!");

            // Nếu đổi tên thì kiểm tra tên mới đã tồn tại chưa (khác với chính nó)
            if (!string.IsNullOrEmpty(dto.TrainName) && dto.TrainName != train.TrainName)
            {
                if (await _unitOfWork.Trains.IsTrainNameExistsAsync(dto.TrainName))
                    throw new Exception("Train name already existed!");

                train.TrainName = dto.TrainName;
            }

            if (dto.EstimatedTime.HasValue)
                train.EstimatedTime = dto.EstimatedTime.Value;

            if (dto.Capacity.HasValue)
                train.Capacity = dto.Capacity.Value;

            if (dto.RouteLocationId.HasValue)
                train.RouteLocationId = dto.RouteLocationId.Value;

            await _unitOfWork.Trains.UpdateTrainAsync(train);
            await _unitOfWork.SaveAsync();

            return true;
        }
    }
    }
