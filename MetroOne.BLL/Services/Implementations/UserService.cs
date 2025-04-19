using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
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
            return await _unitOfWork.Users.UpdateUserAsync(dto);
        }


    }
}

