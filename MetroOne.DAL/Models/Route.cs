using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Route
{
    public int RouteId { get; set; }

    public int? StartStationId { get; set; }

    public int? EndStationId { get; set; }

    public string? RouteName { get; set; }

    public int? RouteLocationId { get; set; }

    public virtual Station? EndStation { get; set; }

    public virtual RouteLocation? RouteLocation { get; set; }

    public virtual Station? StartStation { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
