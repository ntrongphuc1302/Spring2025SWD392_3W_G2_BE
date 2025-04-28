using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class CreatePaymentResponse
    {
        public int PaymentId { get; set; }

        public int TicketId { get; set; } 

        public string Method { get; set; } 

        public string Status { get; set; } 

        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}
