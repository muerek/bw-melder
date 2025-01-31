namespace BwMelder.Core.Model;

/// <summary>
/// Represents a club that registers crews and team coaches.
/// </summary>
class Club
{
    public Guid Id { get; private set; } = Guid.Empty;

    /// <summary>
    /// Name of the club.
    /// </summary>
    public required string Name { get; set; }

    public ClubCoach? ClubCoach { get; set; } = null;

    public IList<TeamCoach> TeamCoaches { get; set; } = [];

    public IList<Crew> Crews { get; set; } = [];

    public IList<AccessKey> AccessKeys { get; set; } = [];
}
