using System.ComponentModel.DataAnnotations;

namespace BwMelder.Data.Model;

/// <summary>
/// Dietary choices and restrictions.
/// </summary>
public class Diet
{
    /// <summary>
    /// Choice of diet from basic options offered by the event.
    /// </summary>
    [Display(Name = "Verpflegungsart")]
    public DietaryOptions Choice { get; set; } = DietaryOptions.Omnivore;

    /// <summary>
    /// Details on specific dietary restrictions like allergies.
    /// </summary>
    [Display(Name = "Weitere Hinweise zur Ernährung (Allergien o.ä.)")]
    public string? Restrictions { get; set; } = null;
}
