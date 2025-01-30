namespace BwMelder.Shared.Clubs;

/// <summary>
/// A request to create a new club.
/// </summary>
public class CreateClubRequest
{
    /// <summary>
    /// Name of the Club to be created.
    /// </summary>
    [Required, NotDefault]
    public string Name { get; set; } = string.Empty;
}
