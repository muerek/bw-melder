using System.ComponentModel.DataAnnotations;

namespace BwMelder.Authentication;

/// <summary>
/// DTO holding credentials submitted for a login attempt.
/// </summary>
class UserCredentials
{
    [Required]
    internal string Username { get; set; } = string.Empty;
    [Required]
    internal string Password { get; set; } = string.Empty;
}
