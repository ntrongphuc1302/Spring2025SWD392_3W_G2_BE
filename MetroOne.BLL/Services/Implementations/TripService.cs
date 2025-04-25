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
                    ArrivalTime = dto.ArrivalTime
                };
            
            await _unitOfWork.Trips.CreateTripsAsync(trip);
            await _unitOfWork.SaveAsync();

            return new CreateTripRespone
            {
                TrainId = trip.TrainId,
                DepartureTime = trip.DepartureTime,
                ArrivalTime = trip.ArrivalTime
            };
        }

        public Task<bool> DeleteTripAsync(int TripId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetAllTripsRespone>> GetAllTripsAsync()
        {
            var trips = await _unitOfWork.Trips.GetAllTripAsync();
            return trips.Select(tr => new GetAllTripsRespone 
            {
                TripId = tr.TripId,
                TrainId = tr.TrainId,
                DepartureTime = tr.DepartureTime,
                ArrivalTime = tr.ArrivalTime
            }).ToList();
        }

        public Task<bool> UpdateTripAsync(UpdateStationRequest dto)
        {
            throw new NotImplementedException();
        }
    }
}
