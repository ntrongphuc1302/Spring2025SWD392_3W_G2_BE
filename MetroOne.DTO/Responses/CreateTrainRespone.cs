using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroOne.DTO.Responses
{
    public class CreateTrainRespone
    {
        public string? TrainName { get; set; }

        public int StartStationId { get; set; }

        public int EndStationId { get; set; }
        [Required]
        [Range(50, 500, ErrorMessage = "Capacity must be between 50 and 500")]
        public int Capacity { get; set; }

        public TimeOnly? EstimatedTime { get; set; }
    }
}
