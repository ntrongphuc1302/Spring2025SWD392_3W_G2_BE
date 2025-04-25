using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Requests
{
    public class UpdateTripRequest
    {
        public int TripId { get; set; }
        public int? TrainId { get; set; }
        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

    }
}
