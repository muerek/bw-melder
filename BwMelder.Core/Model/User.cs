namespace BwMelder.Core.Model;

/// <summary>
/// Represents a user who can login to the application.
/// </summary>
class User
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
