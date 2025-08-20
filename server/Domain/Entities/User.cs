using System.ComponentModel.DataAnnotations;

namespace server.Domain.Entities;

public class User
{
    [Required]
    public string Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }
    
    [Required]
    public string PasswordHash { get; set; }
}
