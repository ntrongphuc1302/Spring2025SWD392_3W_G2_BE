using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Trip
{
    public int TripId { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public int? RouteId { get; set; }

    public int? TrainId { get; set; }

    public virtual Route? Route { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Train? Train { get; set; }
}
