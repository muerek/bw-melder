using System.ComponentModel.DataAnnotations;

namespace BwMelder.Core.Model;

/// <summary>
/// Represents a race for which crews can be registered.
/// </summary>
class Race
{
    public int Id { get; set; } = 0;

    /// <summary>
    /// Race number as referenced in official documents.
    /// </summary>
    /// <remarks>May not only be numeric.</remarks>
    [Display(Name = "Rennnummer")]
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Descriptive name of the race.
    /// </summary>
    [Display(Name = "Bezeichnung")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Total number of rowers per crew in this race.
    /// </summary>
    /// <remarks>Does not include coxes.</remarks>
    [Display(Name = "Anzahl Ruderer je Mannschaft")]
    [Range(1, 5)]
    public int RowerCount { get; set; } = 1;

    [Display(Name = "Steuermensch")]
    public bool Coxed { get; set; } = false;
}
