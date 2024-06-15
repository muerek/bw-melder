using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Information on the legal guardian for underage athletes.
/// </summary>
public class LegalGuardian
{
    [Display(Name = "Vorname")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Nachname")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Name")]
    public string FullName => FirstName + " " + LastName;

    public Contact Contact { get; set; } = new();
}
