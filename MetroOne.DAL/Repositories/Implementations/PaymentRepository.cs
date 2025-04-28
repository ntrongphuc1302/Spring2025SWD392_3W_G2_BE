using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Models;
using MetroOne.DAL.Repositories.Interfaces;

namespace MetroOne.DAL.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly MetroonedbContext _context;
        public PaymentRepository(MetroonedbContext context)
        {
            _context = context;
        }
        public async Task AddPaymentAsync(Payment payment)
        {
            var existingPayment = _context.Payments.FirstOrDefault(p => p.TicketId == payment.TicketId);
            if (existingPayment != null)
            {
                throw new Exception("Payment for "+ payment.TicketId +" already exists");
            }

            var ticket = _context.Tickets.FirstOrDefault(t => t.TicketId == payment.TicketId);
            if (ticket == null)
            {
                throw new Exception("Ticket not found");
            }

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            
        }

        public Task DeletePaymentAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Payment>> GetAllPaymentsAsync()
        {
            var payments = _context.Payments.ToList();
            return Task.FromResult(payments);
        }

        public Task<Payment> GetPaymentByIdAsync(int paymentId)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.PaymentId == paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            else
            {
                return Task.FromResult(payment);
            }
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _context.SaveChangesAsync();
        }
    }
}
