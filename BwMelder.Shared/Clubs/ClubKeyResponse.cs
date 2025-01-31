namespace BwMelder.Shared.Clubs;

/// <summary>
/// DTO holding information on the currently active access key assigned to a club.
/// </summary>
public class ClubKeyResponse
{
    /// <summary>
    /// Unique ID of the club in the database.
    /// </summary>
    public required Guid ClubId { get; set; }

    /// <summary>
    /// Friendly name of the club.
    /// </summary>
    public required string ClubName { get; set; }
    
    public required bool IsActive { get; set; }
    
    /// <summary>
    /// Secret URL for accessing the application.
    /// Set to null if the club has no active access keys.
    /// </summary>
    public string? SecretUrl { get; set; }
}
