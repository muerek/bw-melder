namespace BwMelder.Shared.Crews;

/// <summary>
/// A service response summarizing the registration status of a crew.
/// </summary>
public class CrewRegistrationStatusResponse
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