using BwMelder.Shared.Crews;
using BwMelder.Shared.Races;

namespace BwMelder.Shared.Clubs;

/// <summary>
/// A service response describing a crew of a club and its registration progress.
/// The club data is not included.
/// </summary>
public class ClubCrewResponse
{
    /// <summary>
    /// Unique ID of the crew.
    /// </summary>
    public required Guid CrewId { get; set; }
    
    /// <summary>
    /// Registration progress for this crew.
    /// </summary>
    public required RegistrationProgressResponse RegistrationProgress  { get; set; }
    
    /// <summary>
    /// Race this crew starts in.
    /// </summary>
    public required RaceSummaryResponse Race { get; set; }
}