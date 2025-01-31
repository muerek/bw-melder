namespace BwMelder.Shared.Clubs;

/// <summary>
/// DTO holding information on the currently valid access key assigned to a club.
/// </summary>
public class ClubKeyResponse
{
    /// <summary>
    /// Unique ID of the club in the database.
    /// </summary>
    public required Guid ClubId { get; init; }

    /// <summary>
    /// Friendly name of the club.
    /// </summary>
    public required string ClubName { get; init; }
    
    /// <summary>
    /// Secret of the valid access key.
    /// Set to null if the club has none.
    /// </summary>
    public string? Secret { get; init; }
}
