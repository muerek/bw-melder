using BwMelder.Shared.Races;

namespace BwMelder.Web.Utilities.DtoExtensions;

static class RaceResponseExtensions
{
    /// <summary>
    /// Total number of athletes per crew in this race.
    /// This includes rowers and coxes.
    /// </summary>
    internal static int AthleteCount(this RaceResponse race) => race.RowerCount + (race.Coxed ? 1 : 0);

    /// <summary>
    /// Full display name of the race.
    /// </summary>
    internal static string FullName(this RaceResponse race) => $"{race.Number} - {race.Name}";
}
