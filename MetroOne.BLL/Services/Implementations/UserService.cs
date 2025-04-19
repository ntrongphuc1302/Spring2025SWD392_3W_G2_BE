using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Responses;
using Microsoft.EntityFrameworkCore;

namespace MetroOne.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> UpdateUserAsync(UpdateUserRequest dto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(dto.UserId);

            if (await _unitOfWork.Users.IsEmailExistsAsync(dto.Email))
               throw new Exception("Email already exists"); 

            if (user == null)
                throw new Exception("User not found");
            user.Status = dto.Status;
            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.Role = dto.Role ?? "Passenger";
            return await _unitOfWork.Users.UpdateUserAsync(user);
        }

        public async Task<bool> SoftDeleteUserAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null || user.Status == "Deleted")
                return false;

            user.Status = "Deleted";
            user.Email = $"deleted_{Guid.NewGuid()}@example.com";
            user.Phone = "0000000000";
            user.FullName = "Deleted User";
            user.Role = "Deleted";

            await _unitOfWork.Users.UpdateUserAsync(user);
            return true;
        }

        public async Task<List<GetAllUsersResponse>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllActiveUsersAsync();

            return users.Select(u => new GetAllUsersResponse
            {
                Id = u.UserId,
                FullName = u.FullName,
                Email = u.Email,
                Phone = u.Phone,
                Role = u.Role,
                Status = u.Status
            }).ToList();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null || user.Status == "Deleted")
                throw new Exception("User not found");

            return user;
        }

    }
}

