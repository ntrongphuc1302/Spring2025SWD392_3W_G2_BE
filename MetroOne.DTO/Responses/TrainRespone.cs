﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class TrainResponse
    {
        public int TrainId { get; set; }
        public string? TrainName { get; set; }
        public TimeOnly? EstimatedTime { get; set; }
        public int? Capacity { get; set; }
        public string LocationName { get; set; }
    }

}
