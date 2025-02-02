using BwMelder.Shared.TeamCoaches;

namespace BwMelder.Shared.Clubs;

/// <summary>
/// A service response holding all entries made and to be made by a club.
/// </summary>
public class ClubEntriesResponse
{
    public required IList<ClubCrewStatusResponse> Crews { get; set; }
    
    public required IList<TeamCoachResponse> TeamCoaches { get; set; }
}