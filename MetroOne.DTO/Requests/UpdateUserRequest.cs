using System.ComponentModel.DataAnnotations;

public class DeleteUserRequest
{
    [Required]
    public int UserId { get; set; }
}
