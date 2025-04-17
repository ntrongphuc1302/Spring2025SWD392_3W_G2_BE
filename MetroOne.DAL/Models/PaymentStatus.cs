using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class PaymentStatus
{
    public int PaymentId { get; set; }

    public int TicketId { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? PaymentTime { get; set; }

    public string? PaymentStatus1 { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
