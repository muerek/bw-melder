using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Represents an athlete who is part of a crew.
/// </summary>
public class Athlete : Participant
{
    [Display(Name = "Erziehungsberechtigter")]
    public LegalGuardian LegalGuardian { get; set; } = new();

    [Display(Name = "Steuermensch")]
    public bool IsCox { get; set; } = false;

    public Guid CrewId { get; set; } = Guid.Empty;
}
