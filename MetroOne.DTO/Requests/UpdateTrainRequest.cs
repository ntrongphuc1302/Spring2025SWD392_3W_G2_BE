using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Requests
{
    public class UpdateTrainRequest
    {
        public int TrainId { get; set; }
        public string? TrainName { get; set; }
        public int? StartStationId { get; set; }
        public int? EndStationId { get; set; }
        public int? Capacity { get; set; }
        public TimeOnly? EstimatedTime { get; set; }
    }
}
