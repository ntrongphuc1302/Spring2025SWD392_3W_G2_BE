using System;
using System.Collections.Generic;

namespace MetroOne.DAL.Models;

public partial class User
{
    public required int UserId { get; set; }

    public required string FullName { get; set; }

    public required string Password { get; set; }

    public required string Email { get; set; }

    public required string Phone { get; set; }

    public required string Role { get; set; }

    public virtual ICollection<Pass> Passes { get; set; } = new List<Pass>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
