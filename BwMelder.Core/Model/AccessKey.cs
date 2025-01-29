namespace BwMelder.Core.Model;

/// <summary>
/// Represents an access key that allows logging in with a secret.
/// </summary>
class AccessKey
{
    /// <summary>
    /// Unique secret presented by the user to use this access key.
    /// </summary>
    public required string Secret { get; init; }

    /// <summary>
    /// Access key is invalid before this time.
    /// </summary>
    public DateTime NotBefore { get; init; } = DateTime.Now;

    /// <summary>
    /// Access key is invalid after this time.
    /// </summary>
    public DateTime NotAfter { get; init; } = DateTime.Now.AddDays(2);

    /// <summary>
    /// Flag to invalidate the key even within its period of validity.
    /// </summary>
    public bool Active { get; set; } = true;

    public Guid ClubId { get; set; } = Guid.Empty;
}
