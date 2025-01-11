namespace BwMelder.Dto;

/// <summary>
/// DTO representing the access a club has for the application.
/// </summary>
public class ClubAccess
{
    /// <summary>
    /// Unique ID of the club in the database.
    /// </summary>
    public required Guid ClubId { get; set; }

    /// <summary>
    /// Friendly name of the club.
    /// </summary>
    public required string ClubName { get; set; }

    /// <summary>
    /// Secret URL for accessing the application.
    /// Set to null if the club has no active access.
    /// </summary>
    public string? SecretUrl { get; set; }
}
