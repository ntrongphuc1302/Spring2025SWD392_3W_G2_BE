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

        public int? StartStationId { get; set; }

        public int? EndStationId { get; set; }

        public string? RouteName { get; set; }

        public int? RouteLocationId { get; set; }
    }
}
