using System.ComponentModel.DataAnnotations;

namespace BwMelder.Core.Model;

/// <summary>
/// Address data made up of street, zip and city.
/// </summary>
class Address
{
    [Display(Name = "Anschrift")]
    public string Street { get; set; } = string.Empty;

    [Display(Name = "PLZ")]
    [DataType(DataType.PostalCode)]
    public string Zip { get; set; } = string.Empty;

    [Display(Name = "Ort")]
    public string City { get; set; } = string.Empty;

    [Display(Name = "Adresse")]
    public string Summary => $"{Street}, {Zip} {City}";
}
