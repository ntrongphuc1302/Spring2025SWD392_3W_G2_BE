﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Requests
{
    public class CreateStationRequest
    {
        public string? StationName { get; set; }
        public int LocationId { get; set; }
    }
}
