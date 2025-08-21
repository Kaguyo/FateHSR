using System.ComponentModel.DataAnnotations;

namespace server.src.Domain.Entities;

public class User
{
    [Required]
    public int Id { get; set; } = 0;

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    override public string ToString()
    {
        return $"Id: {Id}, Username: {Username}, Email: {Email}";
    }
}
