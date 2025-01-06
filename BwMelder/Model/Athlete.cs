using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Represents an athlete who is part of a crew.
/// </summary>
public class Athlete : Participant
{
    [Display(Name = "Erziehungsberechtigter")]
    public LegalGuardian LegalGuardian { get; set; } = new();

    [Display(Name = "Position")]
    public Position Position { get; set; } = Position.Rower1;

    public Guid CrewId { get; set; } = Guid.Empty;
}
