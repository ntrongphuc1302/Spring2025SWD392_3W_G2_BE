using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Trip
{
    public int TripId { get; set; }

    public int TrainId { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    //public string? TrainCode { get; set; }

    public string? CoachNumber { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Train Train { get; set; } = null!;
}
