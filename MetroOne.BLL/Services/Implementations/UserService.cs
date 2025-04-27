using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.UnitOfWork;

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

            if (await _unitOfWork.Users.IsEmailExistsAsync(dto.Email, dto.UserId))
        

            if (user == null)
                throw new Exception("User not found");
            user.Status = dto.Status;
            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.Permission = dto.Permission;
            return await _unitOfWork.Users.UpdateUserAsync(user);
        }

        public async Task<bool> SoftDeleteUserAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user == null || user.Status == "Deleted")
                return false;

            user.Status = "Deleted";
            user.Email = $"deleted_{Guid.NewGuid()}@deleted.com"; 
            user.FullName = "Deleted User";

            user.Password = $"{Guid.NewGuid()}";
            
            await _unitOfWork.Users.UpdateUserAsync(user);
            return true;
        }

        public async Task<List<GetAllUsersResponse>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllActiveUsersAsync();

            return users.Select(u => new GetAllUsersResponse
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Email = u.Email,
                Permission = u.Permission,
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

        public async Task<bool> HardDeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user != null)
            {
                var userId = user.UserId;

                if (user.Status != "Deleted")
                    throw new Exception("This User cannot be Hard deleted");

                var result = await _unitOfWork.Users.HardDeleteUserAsync(userId);
                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    return true;
                }
                else
                {
                    throw new Exception("Failed to delete user");
                }
            } else
            {
                throw new Exception("User not found");
            }

        }
    }
}

