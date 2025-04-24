using System.ComponentModel.DataAnnotations;

public class UpdateUserRequest
{
    public int UserId { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public string? Role { get; set; }
    public string? Status { get; set; }
}
