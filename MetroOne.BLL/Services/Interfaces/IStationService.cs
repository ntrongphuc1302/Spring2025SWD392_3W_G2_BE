using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DTO.Requests;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface IStationService
    {
        Task<bool> UpdateStationAsync(UpdateStationRequest dto);
    }
}
