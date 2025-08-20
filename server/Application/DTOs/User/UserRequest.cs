using System.ComponentModel.DataAnnotations;

namespace server.Application.DTOs.User;

public class UserRequest
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
