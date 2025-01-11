namespace BwMelder.Model;

public class AccessKey
{
    public int Id { get; set; } = 0;

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
