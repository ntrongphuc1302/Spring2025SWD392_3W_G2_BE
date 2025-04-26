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

<<<<<<< HEAD
        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public string StartStation { get; set; }
        public string EndStation { get; set; }
=======
        public int? UserId { get; set; }

        public int? TripId { get; set; }
>>>>>>> fd3de8eb0f1f13023ed6602247e97c44a7f2a3f7

        public DateTime? BookingTime { get; set; }

        public decimal? Price { get; set; }

        public string? Status { get; set; }

        public DateTime? ValidTo { get; set; }
    }
}
