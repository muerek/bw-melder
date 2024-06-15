using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Represents a club that registers crews and team coaches.
/// </summary>
public class Club
{
    public Guid Id { get; set; } = Guid.Empty;

    /// <summary>
    /// Name of the club.
    /// </summary>
    [Display(Name = "Vereinsname")]
    public string Name { get; set; } = string.Empty;
}
