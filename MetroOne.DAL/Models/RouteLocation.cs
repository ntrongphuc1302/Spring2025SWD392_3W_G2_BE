using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class RouteLocation
{
    public int RouteLocationId { get; set; }

    public int? LocationId { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<Route> Routes { get; set; } = new List<Route>();

    public virtual ICollection<Train> Trains { get; set; } = new List<Train>();
}
