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
    public interface ILocationService
    {
        Task<List<GetAllLocationResponse>> GetAllLocationsAsync();
        Task<CreateLocationRespone> CreateLocationAsync(CreateLocationRequest dto);
        Task<bool> DeleteLocation(int id);
        Task<Location> GetLocationByIdAsync(int id);
        Task<Location> GetLocationByNameAsync(string name);
    }
}
