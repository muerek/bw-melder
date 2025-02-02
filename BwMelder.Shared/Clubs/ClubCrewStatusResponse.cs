using BwMelder.Shared.Crews;
using BwMelder.Shared.Races;

namespace BwMelder.Shared.Clubs;

/// <summary>
/// A service response summarizing the registration status for a crew.
/// This does not include information on the club.
/// </summary>
public class ClubCrewStatusResponse
{
    public required Guid CrewId { get; set; }
    
    public required RaceSummaryResponse Race { get; set; }
    
    public required CrewRegistrationStatusResponse Status { get; set; }
}