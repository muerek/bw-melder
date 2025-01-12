using System.ComponentModel.DataAnnotations;

namespace BwMelder.Data.Model;

/// <summary>
/// Coach accompanying the team to the event.
/// </summary>
public class TeamCoach : Participant
{
    public Contact Contact { get; set; } = new();

    [Display(Name = "Führerschein")]
    public DriversLicense DriversLicense { get; set; } = DriversLicense.None;

    public Guid ClubId { get; set; } = Guid.Empty;
}