namespace BwMelder.Shared.Athletes;

/// <summary>
/// Describes a service to manage athletes.
/// </summary>
public interface IAthleteService
{
    Task<IReadOnlyList<AthleteSummaryResponse>> GetAthletesAsync();
}