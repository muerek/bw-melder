using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Represents a race for which crews can be registered.
/// </summary>
public class Race
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
    /// Full display name of the race.
    /// </summary>
    public string FullName => $"{Number} - {Name}";

    /// <summary>
    /// Total number of rowers per crew in this race.
    /// </summary>
    /// <remarks>
    /// Does not include coxes. Check <see cref="AthleteCount"/> to account for coxes as well.
    /// </remarks>
    [Display(Name = "Anzahl Ruderer je Mannschaft")]
    [Range(1, 5)]
    public int RowerCount { get; set; } = 1;

    [Display(Name = "Steuermensch")]
    public bool Coxed { get; set; } = false;

    /// <summary>
    /// Total number of athletes per crew in this race.
    /// </summary>
    [Display(Name = "Anzahl Sportler je Mannschaft")]
    public int AthleteCount => RowerCount + (Coxed ? 1 : 0);
}
