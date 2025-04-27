using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Requests
{
    public class CreateTrainRequest
    {
        public string? TrainName { get; set; }
        public TimeOnly? EstimatedTime { get; set; }
        public int Capacity { get; set; }
        public int RouteLocationId { get; set; }
    }
}
