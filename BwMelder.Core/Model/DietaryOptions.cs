using System.ComponentModel.DataAnnotations;

namespace BwMelder.Core.Model;

/// <summary>
/// Different dietary options.
/// </summary>
enum DietaryOptions
{
    [Display(Name = "Allesesser")]
    Omnivore = 0,
    [Display(Name = "Vegetarisch")]
    Vegetarian = 1,
    [Display(Name = "Vegan")]
    Vegan = 2
}
