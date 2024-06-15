using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model;

/// <summary>
/// Represents different types of drivers license.
/// Uses broad generic types only as the specifics vary by issue date. 
/// </summary>
public enum DriversLicense
{
    [Display(Name = "Kein Führerschein")]
    None = 0,
    [Display(Name = "PKW (B oder gleichwertig)")]
    Car = 1,
    [Display(Name = "Anhänger (BE oder gleichwertig)")]
    Trailer = 2
}
