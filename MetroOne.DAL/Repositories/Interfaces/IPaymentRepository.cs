using MetroOne.DAL.Models;

namespace MetroOne.DAL.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentByIdAsync(int paymentId);
        Task<List<Payment>> GetAllPaymentsAsync();
        Task AddPaymentAsync(Payment payment);
        Task UpdatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(int paymentId);
    }
}
