namespace BwMelder.Model;

public class AccessKey
{
    public int Id { get; set; } = 0;

    public required string Secret { get; init; }

    /// <summary>
    /// Access key is invalid before this time.
    /// </summary>
    public DateTime NotBefore { get; } = DateTime.Now;

    /// <summary>
    /// Access key is invalid after this time.
    /// </summary>
    public DateTime NotAfter { get; init; } = DateTime.Now.AddDays(2);

    /// <summary>
    /// Flag to invalidate the key even within its period of validity.
    /// </summary>
    public bool Activated { get; set; } = true;

    /// <summary>
    /// Determines if the access key is still valid for use.
    /// </summary>
    public bool IsValid => Activated && NotBefore <= DateTime.Now && DateTime.Now <= NotAfter;

    public Guid ClubId { get; set; } = Guid.Empty;
}
