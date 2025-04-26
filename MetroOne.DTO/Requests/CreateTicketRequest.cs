using System.ComponentModel;
using static MetroOne.DTO.Constants.ApiRoutes;

public class CreateTicketRequest
{
    public int? UserId { get; set; }

    public int? TripId { get; set; }

    [DefaultValue("15000.00")]
    public decimal? Price { get; set; }
    [DefaultValue("Active")]
    public string? Status { get; set; }
    [DefaultValue("2023-10-01T00:00:00Z")]
    public DateTime? ValidTo { get; set; }

}
