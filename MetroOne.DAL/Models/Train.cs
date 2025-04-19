using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Train
{
    public int TrainId { get; set; }

    public string? TrainName { get; set; }

    public int StartStationId { get; set; }

    public int EndStationId { get; set; }
    public int Capacity { get; set; }

    public TimeOnly? EstimatedTime { get; set; }

    public virtual Station EndStation { get; set; } = null!;

    public virtual Station StartStation { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
