public class CreateTicketResponse
{
    public int TicketId { get; set; }

    public int? UserId { get; set; }

    public int? TripId { get; set; }

    public DateTime? BookingTime { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public DateTime? ValidTo { get; set; }
}
