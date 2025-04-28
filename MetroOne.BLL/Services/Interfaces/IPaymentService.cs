using MetroOne.DAL.Models;
using System.Collections.Generic;
using MetroOne.DTO.Responses;
using System.Threading.Tasks;
using MetroOne.DTO.Requests;

namespace MetroOne.BLL.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<CreatePaymentResponse> GetPaymentByIdAsync(int paymentId);
        Task<List<CreatePaymentResponse>> GetAllPaymentsAsync();
        Task<CreatePaymentResponse> AddPaymentAsync(CreatePaymentRequest payment);
        Task<bool> UpdatePaymentAsync(UpdatePaymentRequest payment);
        Task DeletePaymentAsync(int paymentId);
    }
}
