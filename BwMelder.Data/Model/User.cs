using System.ComponentModel.DataAnnotations;

namespace BwMelder.Data.Model;

/// <summary>
/// Represents a user who can login to the application.
/// </summary>
public class User
{
    [Required]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
}
