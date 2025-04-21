using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DTO.Responses;
using MetroOne.DTO.Requests;
using MetroOne.DAL.Models;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> UpdateUserAsync(UpdateUserRequest dto);
        Task<bool> SoftDeleteUserAsync(int userId);
        Task<List<GetAllUsersResponse>> GetAllUsersAsync();
        Task<User> GetByIdAsync(int id);
        Task<bool> HardDeleteUserAsync(int id);

    }

}
