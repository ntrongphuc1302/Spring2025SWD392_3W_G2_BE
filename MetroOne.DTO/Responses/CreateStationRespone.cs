using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class CreateStationRespone
    {
        public string? StationName { get; set; }

        public string? StationCode { get; set; }

        public string? Location { get; set; }

        public int? OrderInRoute { get; set; }
    }
}
