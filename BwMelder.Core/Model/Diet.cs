using System.ComponentModel.DataAnnotations;

namespace BwMelder.Core.Model;

/// <summary>
/// Dietary choices and restrictions.
/// </summary>
class Diet
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
