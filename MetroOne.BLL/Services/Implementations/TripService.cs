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
    public class TripService : ITripService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TripService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateTripRespone> CreateTripAsync(CreateTripRequest dto)
        {
            var train = await _unitOfWork.Trains.GetTrainByIdAsync(dto.TrainId);
            if (train == null)
            {
                throw new Exception("Train not found!");
            }
                var trip = new Trip
                {
                    TrainId = train.TrainId,
                    DepartureTime = dto.DepartureTime,
                    ArrivalTime = dto.ArrivalTime,
                    TrainCode = train.TrainName,
                    CoachNumber = dto.CoachNumber //CoachNumber is Status of the train.
                };
            
            await _unitOfWork.Trips.CreateTripsAsync(trip);
            await _unitOfWork.SaveAsync();

            return new CreateTripRespone
            {
                TrainId = trip.TrainId,
                TrainCode = trip.TrainCode,
                DepartureTime = trip.DepartureTime,
                ArrivalTime = trip.ArrivalTime,
                CoachNumber = trip.CoachNumber
            };
        }

        public Task<bool> DeleteTripAsync(int TripId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTripAsync(UpdateStationRequest dto)
        {
            throw new NotImplementedException();
        }
    }
}
