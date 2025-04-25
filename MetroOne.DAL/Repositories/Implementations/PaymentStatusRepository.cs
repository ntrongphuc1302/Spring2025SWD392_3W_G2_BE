using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        private readonly MetroonedbContext _context;

        public PaymentStatusRepository(MetroonedbContext context)
        {
            _context = context;
        }

        public Task<bool> CreateAsync(string paymentStatus)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            var paymentStatus = _context.PaymentStatuses.FirstOrDefault(p => p.PaymentId == id);
            if (paymentStatus != null)
            {
                _context.PaymentStatuses.Remove(paymentStatus);
                return Task.FromResult(_context.SaveChanges() > 0);
            }
            else
            {
                throw new Exception("Payment status not found");
            }
        }

        public Task<PaymentStatus> GetByIdAsync(int id)
        {
            var paymentStatus = _context.PaymentStatuses.FirstOrDefault(p => p.PaymentId == id);
            if (paymentStatus == null)
            {
                throw new Exception("Payment status not found");
            }
            else
            {
                return Task.FromResult(paymentStatus);
            }
        }

        public Task<PaymentStatus> GetByTicketIdAsync(int id)
        {
            var paymentStatus = _context.PaymentStatuses.FirstOrDefault(p => p.TicketId == id);
            if (paymentStatus == null)
            {
                throw new Exception("Payment status not found");
            }
            else
            {
                return Task.FromResult(paymentStatus);
            }
        }

        public Task<List<string>> GetStatusesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, string paymentStatus)
        {
            throw new NotImplementedException();
        }
    }
}
