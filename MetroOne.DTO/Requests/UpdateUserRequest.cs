using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class UpdateUserRequest
{
    public int UserId { get; set; }

    [DefaultValue("Full name")]
    public string? FullName { get; set; }
    [DefaultValue("example@email.com")]
    public string? Email { get; set; }
    [DefaultValue("Your_password")]
    public string? Password { get; set; }
    [DefaultValue("Active")]
    public string? Status { get; set; }
    [DefaultValue("Passenger")]
    public string? Permission { get; set; }
}
