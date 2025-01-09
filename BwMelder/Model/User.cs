using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Represents a user who can login to the application.
/// </summary>
class User
{
    [Required]
    internal string Username { get; set; } = string.Empty;
    
    [Required]
    internal string Password { get; set; } = string.Empty;
}
