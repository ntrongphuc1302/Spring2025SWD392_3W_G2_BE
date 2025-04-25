using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface IPaymentStatusRepository
    {
        Task<List<string>> GetStatusesAsync();
        Task<PaymentStatus> GetByIdAsync(int id);
        Task<PaymentStatus> GetByTicketIdAsync(int id);
        Task<bool> CreateAsync(string paymentStatus);
        Task<bool> UpdateAsync(int id, string paymentStatus);
        Task<bool> DeleteAsync(int id);
    }
}
