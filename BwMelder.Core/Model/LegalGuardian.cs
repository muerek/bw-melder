namespace BwMelder.Core.Model;

/// <summary>
/// Information on the legal guardian for underage athletes.
/// </summary>
record LegalGuardian
{
    public required Name Name { get; set; }

    public required Contact Contact { get; set; }
}
