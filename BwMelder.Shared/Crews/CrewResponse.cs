using BwMelder.Shared.Clubs;
using BwMelder.Shared.Races;

namespace BwMelder.Shared.Crews;

/// <summary>
/// A service response describing a crew.
/// </summary>
public class CrewResponse
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
    /// Club the crew belongs to.
    /// </summary>
    public required ClubResponse Club { get; set; }
    
    /// <summary>
    /// Race this crew starts in.
    /// </summary>
    public required RaceSummaryResponse Race { get; set; }
}