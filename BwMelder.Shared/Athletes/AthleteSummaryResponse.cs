namespace BwMelder.Shared.Athletes;

/// <summary>
/// A service response summarizing information on an athlete.
/// </summary>
public record AthleteSummaryResponse
{
    /// <summary>
    /// Unique ID of the athlete record.
    /// </summary>
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Full name of the athlete.
    /// </summary>
    public required string Name { get; init; }
    
    public required Position Position { get; init; }
}