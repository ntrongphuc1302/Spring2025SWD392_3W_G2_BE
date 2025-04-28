using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class TicketDetailResponse
    {
        public int TicketId { get; set; }
        public string TicketStatus { get; set; }
        public decimal? Price { get; set; }
        public DateTime? BookingTime { get; set; }
        public DateTime? ValidTo { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        // Add other properties as needed
    }

}
