namespace BwMelder.Core.Model;

/// <summary>
/// Coach responsible for a club's crews before and after the event.
/// Primary contact for all event-related communication.
/// </summary>
class ClubCoach
{
    public int Id { get; private set; } = 0;

    public required Name Name { get; set; }

    public required Contact Contact { get; set; }

    public Guid ClubId { get; set; } = Guid.Empty;
}
