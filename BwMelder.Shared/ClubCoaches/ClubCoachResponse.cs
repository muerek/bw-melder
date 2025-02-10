namespace BwMelder.Shared.ClubCoaches;

/// <summary>
/// A service response describing a club coach.
/// </summary>
public record ClubCoachResponse
{
    /// <summary>
    /// Unique ID of this club coach.
    /// </summary>
    public required int Id { get; init; }
    
    /// <summary>
    /// Full name.
    /// </summary>
    public required string Name { get; init; }
    
    /// <summary>
    /// Contact information.
    /// </summary>
    public required ContactResponse Contact { get; init; }
}