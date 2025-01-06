namespace BwMelder.Model;

/// <summary>
/// Represents a crew for a race.
/// </summary>
public class Crew
{
    public Guid Id { get; set; } = Guid.Empty;

    public Guid ClubId { get; set; } = Guid.Empty;

    public int RaceId { get; set; } = 0;

    public IList<Athlete> Athletes { get; set; } = new List<Athlete>();
}
