namespace BwMelder.Core.Model;

/// <summary>
/// Coach accompanying the team to the event.
/// </summary>
class TeamCoach : Participant
{
    public required Contact Contact { get; set; }

    public DriversLicense DriversLicense { get; set; } = DriversLicense.None;

    public Guid ClubId { get; set; } = Guid.Empty;
}