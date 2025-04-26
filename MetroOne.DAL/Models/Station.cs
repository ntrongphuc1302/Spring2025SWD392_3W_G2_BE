using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Station
{
    public int StationId { get; set; }

    public string? StationName { get; set; }

    public int? LocationId { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<Route> RouteEndStations { get; set; } = new List<Route>();

    public virtual ICollection<Route> RouteStartStations { get; set; } = new List<Route>();
}
