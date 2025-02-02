using BwMelder.Shared.Clubs;
using BwMelder.Shared.Races;

namespace BwMelder.Shared.Crews;

/// <summary>
/// A service response summarizing the registration status for a crew.
/// </summary>
public class RegistrationProgressResponse
{
    /// <summary>
    /// Number of athletes that have been registered for this crew.
    /// </summary>
    public required int CurrentAthleteCount { get; set; }

    /// <summary>
    /// Number of athletes that must be registered to complete the crew.
    /// </summary>
    public required int TargetAthleteCount { get; set; }
}
