using BwMelder.Shared.Races;

namespace BwMelder.Shared.Crews;

/// <summary>
/// A service response describing a crew of a club and its registration progress.
/// The club data is not included.
/// </summary>
public record ClubCrewResponse
{
    /// <summary>
    /// Unique ID of the crew.
    /// </summary>
    public required Guid CrewId { get; init; }
    
    /// <summary>
    /// Registration progress for this crew.
    /// </summary>
    public required RegistrationProgressResponse RegistrationProgress  { get; init; }
    
    /// <summary>
    /// Race this crew starts in.
    /// </summary>
    public required RaceSummaryResponse Race { get; init; }
}