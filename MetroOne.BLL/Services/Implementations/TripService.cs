using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;
using Microsoft.AspNetCore.Routing;

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
            //var route = await _unitOfWork.Routes.GetRouteByIdAsync(dto.RouteId);
            if (train == null)
            {
                throw new Exception("Train not found!");
            }
                var trip = new Trip
                {
                    TrainId = train.TrainId,
                    //RouteId = route.RouteId,
                    DepartureTime = dto.DepartureTime,
                    ArrivalTime = dto.ArrivalTime
                };
            
            await _unitOfWork.Trips.CreateTripsAsync(trip);
            await _unitOfWork.SaveAsync();

            return new CreateTripRespone
            {
                //TrainId = trip.TrainId,
                DepartureTime = trip.DepartureTime,
                ArrivalTime = trip.ArrivalTime,
                TrainName = train.TrainName,     
                //RouteName = route.RouteName      
            };
        }

        public async Task<bool> DeleteTripAsync(int TripId)
        {
            var trip = await _unitOfWork.Trips.GetByTripIdAsync(TripId);
            if(trip != null)
            {
                await _unitOfWork.Trips.DeleteTripsAsync(trip.TripId);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        //public Task<List<GetAllTripsRespone>> GetAllTripsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<GetAllTripsRespone>> GetAllTripsAsync()
        {
            var trips = await _unitOfWork.Trips.GetAllTripAsync();
            return trips.Select(tr => new GetAllTripsRespone
            {
                TripId = tr.TripId,
                DepartureTime = tr.DepartureTime,
                ArrivalTime = tr.ArrivalTime,
                TrainName = tr.Train?.TrainName,    // thêm dòng này
                RouteName = tr.Route?.RouteName     // thêm dòng này
            }).ToList();
        }


        public Task<bool> UpdateTripAsync(UpdateStationRequest dto)
        {
            throw new NotImplementedException();
        }
    }
}
