using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DTO.Requests;
using MetroOne.DTO.Responses;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface IStationService
    {
        Task<List<GetAllStationRespone>> GetAllStationAsync();
        Task<bool> UpdateStationAsync(UpdateStationRequest dto);
        Task<Station> GetStationByIdAsync(int id);
        Task<Station> GetStationByNameAsync(string StationName);
        Task<CreateStationRespone> AddStationAsync(CreateStationRequest dto);
        Task<bool> DeleteStationAsync(int id);
    }
}
