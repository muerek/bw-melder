namespace BwMelder.Web.Authentication;

/// <summary>
/// Represents information on an application user.
/// </summary>
public class UserInfo
{
    public required string Role { get; set; }

    public Guid? ClubId { get; set; }

    public string? ClubName { get; set; }
}
