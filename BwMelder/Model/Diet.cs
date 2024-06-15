using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Dietary choices and restrictions.
/// </summary>
public class Diet
{
    /// <summary>
    /// Choice of diet from basic options offered by the event.
    /// </summary>
    [Display(Name = "Verpflegungsart")]
    public DietaryChoice Choice { get; set; } = DietaryChoice.Normal;

    /// <summary>
    /// Details on specific dietary restrictions like allergies.
    /// </summary>
    [Display(Name = "Weitere Hinweise zur Ernährung (Allergien o.ä.)")]
    public string? Restrictions { get; set; } = null;
}

public enum DietaryChoice
{
    [Display(Name = "Normalkost")]
    Normal = 0,
    [Display(Name = "Vegetarisch")]
    Vegetarian = 1,
    [Display(Name = "Vegan")]
    Vegan = 2
}
