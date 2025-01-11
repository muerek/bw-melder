namespace BwMelder.Dto;

/// <summary>
/// DTO representing a request to create a new club.
/// </summary>
public class CreateClubRequest
{
    /// <summary>
    /// Name of the Club to be created.
    /// </summary>
    public required string Name { get; set; }
}
