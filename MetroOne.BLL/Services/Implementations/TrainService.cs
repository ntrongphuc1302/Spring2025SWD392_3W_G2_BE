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
                StartStationId = dto.StartStationId,
                EndStationId = dto.EndStationId,
                Capacity = dto.Capacity,
            };
            
            await _unitOfWork.Trains.AddTrainAsync(train);
            await _unitOfWork.SaveAsync();

            return new CreateTrainRespone
            {
                TrainName = train.TrainName,
                EstimatedTime = train.EstimatedTime,
                StartStationId = train.StartStationId,
                EndStationId = train.EndStationId,
                Capacity = train.Capacity
            };
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
                StartStationId = t.StartStationId,
                EndStationId = t.EndStationId,
                Capacity = t.Capacity
                
            }).ToList();
        }

        public async Task<Train> GetTrainByIdAsync(int id)
        {
            var train = await _unitOfWork.Trains.GetTrainByIdAsync(id);
            if(train == null) 
                throw new Exception("Train not found!");
                return train;
        }

        public async Task<Train> GetTrainByNameAsync(string name)
        {
            var train = await _unitOfWork.Trains.GetTrainByNameAsync(name);
            if(train == null)
            {
                throw new Exception("Train not found!");
            }
            return train;
        }

        public async Task<bool> UpdateTrainAsync(UpdateTrainRequest dto)
        {
            var train = await _unitOfWork.Trains.GetTrainByIdAsync(dto.TrainId);
            if (train == null)
                throw new Exception("Train not found!");

            if (!string.IsNullOrEmpty(dto.TrainName))
                train.TrainName = dto.TrainName;

            if (dto.EstimatedTime.HasValue)
                train.EstimatedTime = dto.EstimatedTime.Value;

            if (dto.StartStationId.HasValue)
                train.StartStationId = dto.StartStationId.Value;

            if (dto.EndStationId.HasValue)
                train.EndStationId = dto.EndStationId.Value;

            if (dto.Capacity.HasValue)
                train.Capacity = dto.Capacity.Value;

            return await _unitOfWork.Trains.UpdateTrainAsync(train);
        }
    }
}
