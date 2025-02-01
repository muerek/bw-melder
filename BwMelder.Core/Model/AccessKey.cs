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
    
    /// <summary>
    /// Evaluate if this access key is valid for login.
    /// Considers both the expiration set by <see cref="NotAfter"/> and the <see cref="Active"/> flag.
    /// </summary>
    /// <remarks>Cannot be queried directly from the database.</remarks>
    public bool IsValid => Active && DateTime.Now <= NotAfter;
}
