using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Requests
{
    public class UpdateTicketRequest
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public int TripId { get; set; }
        public int StartStationId { get; set; }
        public int EndStationId { get; set; }
        public decimal Price { get; set; }
        public string? Status { get; set; } = "Pending";
        public string? QRCode { get; set; }
    }
}
