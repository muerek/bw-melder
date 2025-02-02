using BwMelder.Shared.Clubs;
using BwMelder.Shared.Races;

namespace BwMelder.Shared.Crews;

/// <summary>
/// A service response summarizing the details and registration status for a crew.
/// </summary>
public class CrewSummaryResponse
{
    public required Guid CrewId { get; set; }
    
    public required RaceSummaryResponse Race { get; set; }

    public required ClubResponse Club { get; set; }
    
    public required CrewRegistrationStatusResponse Status { get; set; }
}
