using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Coach accompanying the team to the event.
/// </summary>
public class TeamCoach : Participant
{
    public Contact Contact { get; set; } = new();

    [Display(Name = "Verein")]
    public string ClubName { get; set; } = string.Empty;

    [Display(Name = "Führerschein")]
    public DriversLicense DriversLicense { get; set; } = DriversLicense.None;
}