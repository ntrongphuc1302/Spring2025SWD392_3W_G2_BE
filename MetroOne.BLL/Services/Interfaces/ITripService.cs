using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface ITripService
    {
        Task<CreateTripRespone> CreateTripAsync(CreateTripRequest dto);
        Task<bool> UpdateTripAsync(UpdateStationRequest dto);
        Task<bool> DeleteTripAsync(int TripId);
    }
}
