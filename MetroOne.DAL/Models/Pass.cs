using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class Pass
{
    public int PassId { get; set; }

    public int UserId { get; set; }

    public string? PassType { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? Price { get; set; }

    public int? RemainingUses { get; set; }

    public virtual User User { get; set; } = null!;
}
