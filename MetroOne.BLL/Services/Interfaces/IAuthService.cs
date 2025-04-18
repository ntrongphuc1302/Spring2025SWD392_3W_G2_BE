using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DTO.Responses;
using MetroOne.DTO.Requests;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest dto);
        Task<RegisterResponse?> RegisterAsync(RegisterRequest dto);

    }

}
