namespace BwMelder.Core.Model;

/// <summary>
/// Represents an athlete who is part of a crew.
/// </summary>
class Athlete : Participant
{
    public required LegalGuardian LegalGuardian { get; set; }

    public Position Position { get; set; } = Position.Rower1;

    public Guid CrewId { get; set; } = Guid.Empty;
}
