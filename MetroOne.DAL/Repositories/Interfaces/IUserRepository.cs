using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DTO.Responses;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<Boolean> IsEmailExistsAsync(string email, int userId);
        Task<Boolean> CreateAsync(User user);
        Task<bool> UpdateUserAsync(User dto);
        Task<List<User>> GetAllActiveUsersAsync();
        Task<bool> HardDeleteUserAsync(int id);

    }
}
