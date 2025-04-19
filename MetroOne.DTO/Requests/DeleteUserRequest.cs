using System.ComponentModel.DataAnnotations;

public class UpdateUserRequest
{
    [Required]
    public int UserId { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public required string FullName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public required string Email { get; set; }

    [Required]
    [RegularExpression(@"^(0|\+84)[3|5|7|8|9]\d{8}$", ErrorMessage = "Invalid phone number.")]
    public required string Phone { get; set; }

    [Required]
    [RegularExpression(@"^(Admin|Passenger)$", ErrorMessage = "Role must be either Admin or Passenger.")]
    public string? Role { get; set; }

    [RegularExpression(@"^(Active|Deactivated|Deleted)$", ErrorMessage = "Status must be Active, Deactivated or Deleted")]
    public string? Status { get; set; }
}
