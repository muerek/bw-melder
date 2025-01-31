namespace BwMelder.Core.Model;

/// <summary>
/// Contact information for phone and email correspondence.
/// </summary>
record Contact
{
    public required string Phone { get; set; }

    public required string EmailAddress { get; set; }
}