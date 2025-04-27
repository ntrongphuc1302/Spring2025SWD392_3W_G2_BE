using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Requests
{
    public class UpdateRouteLoacationRequest
    {
        public int RouteLocationId { get; set; }
        public int? LocationId { get; set; }
    }
}
