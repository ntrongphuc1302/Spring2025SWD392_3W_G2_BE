using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int UserId { get; set; }

    public int TripId { get; set; }

    public int StartStationId { get; set; }

    public int EndStationId { get; set; }

    public DateTime? BookingTime { get; set; }

    public decimal? Price { get; set; }

    public string? Qrcode { get; set; }

    public string? Status { get; set; }

    public virtual Station EndStation { get; set; } = null!;

    public virtual PaymentStatus? PaymentStatus { get; set; }

    public virtual Station StartStation { get; set; } = null!;

    public virtual Trip Trip { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
