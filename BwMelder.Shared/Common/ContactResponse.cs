namespace BwMelder.Shared.Common;

/// <summary>
/// A service response holding contact information.
/// </summary>
public record ContactResponse
{
    public required string Phone { get; init; }

    public required string EmailAddress { get; init; }
}