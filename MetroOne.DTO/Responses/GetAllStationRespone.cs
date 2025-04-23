using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class GetAllStationRespone
    {
        public int StationId { get; set; }

        public string? StationName { get; set; }

        public string? StationCode { get; set; }

        public string? Location { get; set; }

        public int? OrderInRoute { get; set; }
    }
}
