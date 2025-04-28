using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.BLL.Services.Interfaces;
using MetroOne.DAL.Models;
using MetroOne.DAL.UnitOfWork;
using MetroOne.DTO.Responses;
using MetroOne.DTO.Requests;
using static MetroOne.DTO.Constants.ApiRoutes;

namespace MetroOne.BLL.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CreatePaymentResponse> AddPaymentAsync(CreatePaymentRequest payment)
        {
            var newPayment = new DAL.Models.Payment
            {
                TicketId = payment.TicketId,
                Method = payment.Method,
                Status = payment.Status,
                PaymentDate = payment.PaymentDate
            };
            await _unitOfWork.Payments.AddPaymentAsync(newPayment);

            return new CreatePaymentResponse
            {
                PaymentId = newPayment.PaymentId,
                TicketId = newPayment.TicketId,
                Method = newPayment.Method,
                Status = newPayment.Status,
                PaymentDate = newPayment.PaymentDate
            };
        }

        public Task DeletePaymentAsync(int paymentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CreatePaymentResponse>> GetAllPaymentsAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllPaymentsAsync();
            if (payments == null)
            {
                throw new Exception("No payments found");
            }
            else
            {
                return payments.Select(payment => new CreatePaymentResponse
                {
                    PaymentId = payment.PaymentId,
                    TicketId = payment.TicketId,
                    Method = payment.Method,
                    Status = payment.Status,
                    PaymentDate = payment.PaymentDate
                }).ToList();
            }
        }

        public async Task<CreatePaymentResponse> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _unitOfWork.Payments.GetPaymentByIdAsync(paymentId);
            if (payment == null)
            {
                throw new Exception("Payment not found");
            }
            else
            {
                return new CreatePaymentResponse
                {
                    PaymentId = payment.PaymentId,
                    TicketId = payment.TicketId,
                    Method = payment.Method,
                    Status = payment.Status,
                    PaymentDate = payment.PaymentDate
                };
            }
        }

        public async Task<bool> UpdatePaymentAsync(UpdatePaymentRequest payment)
        {
            var existingPayment = await _unitOfWork.Payments.GetPaymentByIdAsync(payment.PaymentId);
            if (existingPayment == null)
            {
                throw new Exception("Payment not found");
            }
            else
            {
                existingPayment.TicketId = payment.TicketId;
                existingPayment.Method = payment.Method;
                existingPayment.Status = payment.Status;
                existingPayment.PaymentDate = payment.PaymentDate;
                await _unitOfWork.Payments.UpdatePaymentAsync(existingPayment);
                return true;
            }
        }
    }
}
