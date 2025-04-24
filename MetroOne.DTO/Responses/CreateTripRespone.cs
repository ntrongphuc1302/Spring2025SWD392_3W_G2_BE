using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class CreateTripRespone
    {
        public int TrainId { get; set; }

        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public string? TrainCode { get; set; }

        public string? CoachNumber { get; set; }
    }
}
