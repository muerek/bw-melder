namespace BwMelder.Core.Model;

/// <summary>
/// Represents a race for which crews can be registered.
/// </summary>
class Race
{
    public int Id { get; private set; } = 0;

    /// <summary>
    /// Race number as referenced in official documents.
    /// </summary>
    /// <remarks>May not only be numeric.</remarks>
    public required string Number { get; set; }

    /// <summary>
    /// Descriptive name of the race.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Total number of rowers per crew in this race.
    /// </summary>
    /// <remarks>Does not include coxes.</remarks>
    public int RowerCount { get; set; } = 1;

    /// <summary>
    /// Flag if crews require a cox or not.
    /// </summary>
    public bool Coxed { get; set; } = false;

    /// <summary>
    /// Limit of crews allowed to be nominated for this race.
    /// </summary>
    public int? CrewCount { get; set; } = 2;

    /// <summary>
    /// Total number of athletes per crew in this race.
    /// This is all rowers and coxes.
    /// </summary>
    public int AthleteCount => RowerCount + (Coxed ? 1 : 0);
}
