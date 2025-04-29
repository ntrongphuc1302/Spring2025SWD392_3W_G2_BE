using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class GetRouteResponse
    {
        public int RouteId { get; set; }

        public string StartStationName { get; set; }

        public string EndStationName { get; set; }

        public string? RouteName { get; set; }

        public int? RouteLocationId { get; set; }
    }
}
