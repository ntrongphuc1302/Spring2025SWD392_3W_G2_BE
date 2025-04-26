using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Train
{
    public int TrainId { get; set; }

    public string? TrainName { get; set; }

    public TimeOnly? EstimatedTime { get; set; }

    public int? Capacity { get; set; }

    public int? RouteLocationId { get; set; }

    public virtual RouteLocation? RouteLocation { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
