using System.ComponentModel.DataAnnotations;

namespace BwMelder.Authentication;

/// <summary>
/// DTO holding credentials submitted for a login attempt.
/// </summary>
public class UserCredentials
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
