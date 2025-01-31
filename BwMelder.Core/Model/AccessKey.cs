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
    /// Access key is invalid after this time.
    /// </summary>
    public DateTime NotAfter { get; init; } = DateTime.Now.AddDays(2);

    /// <summary>
    /// Flag to manually deactivate this access key.
    /// This invalidates the key even if it is still before the expiration set by <see cref="NotAfter"/>.
    /// </summary>
    public bool Active { get; init; } = true;
    
    public Guid ClubId { get; set; } = Guid.Empty;
    
    public bool IsValid => Active && DateTime.Now <= NotAfter;
}
