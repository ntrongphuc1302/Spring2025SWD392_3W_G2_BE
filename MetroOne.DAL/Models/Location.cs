using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? LocationName { get; set; }

    public virtual RouteLocation? RouteLocation { get; set; }

    public virtual ICollection<Station> Stations { get; set; } = new List<Station>();
}
