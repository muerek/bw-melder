using BwMelder.Shared.Clubs;
using BwMelder.Shared.Races;

namespace BwMelder.Shared.Crews;

/// <summary>
/// A service response describing a crew.
/// </summary>
public record CrewResponse
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
    /// Club the crew belongs to.
    /// </summary>
    public required ClubResponse Club { get; init; }
    
    /// <summary>
    /// Race this crew starts in.
    /// </summary>
    public required RaceSummaryResponse Race { get; init; }
}