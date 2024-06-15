using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Coach responsible for a club's crews before and after the event.
/// Primary contact for all event-related communication.
/// </summary>
public class ClubCoach
{
    public int Id { get; set; } = 0;

    [Display(Name = "Vorname")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Nachname")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Name")]
    public string FullName => $"{FirstName} {LastName}";

    public Contact Contact { get; set; } = new();
}
