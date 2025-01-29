namespace BwMelder.Core.Model;

/// <summary>
/// Address data made up of street, zip and city.
/// </summary>
record Address
{
    public string Street { get; set; } = string.Empty;

    public string Zip { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Summary => $"{Street}, {Zip} {City}";
}
