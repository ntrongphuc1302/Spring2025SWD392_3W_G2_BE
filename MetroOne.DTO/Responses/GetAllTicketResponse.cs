using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MetroOne.DTO.Constants.ApiRoutes;

namespace MetroOne.DTO.Responses
{
    public class GetAllTicketResponse
    {
        public int TicketId { get; set; }

        public int? UserId { get; set; }

        public int? TripId { get; set; }

        public DateTime? BookingTime { get; set; }

        public decimal? Price { get; set; }

        public string? Status { get; set; }

        public DateTime? ValidTo { get; set; }
    }
}
