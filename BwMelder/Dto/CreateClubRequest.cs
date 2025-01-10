namespace BwMelder.Dto;

/// <summary>
/// DTO holding data required for club creation.
/// </summary>
public class CreateClubRequest
{
    /// <summary>
    /// Name of the Club to be created.
    /// </summary>
    public required string Name { get; set; }
}
