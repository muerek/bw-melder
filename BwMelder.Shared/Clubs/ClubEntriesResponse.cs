using BwMelder.Shared.Crews;
using BwMelder.Shared.TeamCoaches;

namespace BwMelder.Shared.Clubs;

/// <summary>
/// A service response holding all entries made and to be made by a club.
/// </summary>
public record ClubEntriesResponse
{
    public required IReadOnlyList<CrewByClubResponse> Crews { get; init; }
    
    public required IReadOnlyList<TeamCoachResponse> TeamCoaches { get; init; }
}