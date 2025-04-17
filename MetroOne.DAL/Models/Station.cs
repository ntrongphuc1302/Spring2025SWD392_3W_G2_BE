using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Station
{
    public int StationId { get; set; }

    public string? StationName { get; set; }

    public string? StationCode { get; set; }

    public string? Location { get; set; }

    public int? OrderInRoute { get; set; }

    public virtual ICollection<Ticket> TicketEndStations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketStartStations { get; set; } = new List<Ticket>();

    public virtual ICollection<Train> TrainEndStations { get; set; } = new List<Train>();

    public virtual ICollection<Train> TrainStartStations { get; set; } = new List<Train>();
}
