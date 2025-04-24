public class CreateTicketRequest
{
    public int UserId { get; set; }
    public int TripId { get; set; }
    public int StartStationId { get; set; }
    public int EndStationId { get; set; }
    public decimal Price { get; set; }
    public string? Status { get; set; } = "Pending";
    public string? QRCode { get; set; }
}
