using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class GetAllTicketResponse
    {
        public int TicketId { get; set; }

        public int UserId { get; set; }

        public int TripId { get; set; }

        public int StartStationId { get; set; }

        public int EndStationId { get; set; }

        public DateTime? BookingTime { get; set; }

        public decimal? Price { get; set; }

        public string? Qrcode { get; set; }

        public string? Status { get; set; }
    }
}
