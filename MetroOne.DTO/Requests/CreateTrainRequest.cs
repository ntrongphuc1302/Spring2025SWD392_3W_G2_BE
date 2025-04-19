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
        [Required]
        public required string TrainName { get; set; }

        public int StartStationId { get; set; }

        public int EndStationId { get; set; }

        public TimeOnly? EstimatedTime { get; set; }

    }
}
