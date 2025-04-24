using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface ITicketService
    {
        Task<CreateTicketResponse> CreateTicketAsync(CreateTicketRequest request);
    }
}
