namespace BwMelder.Shared.Clubs;

/// <summary>
/// Represents a service to manage clubs.
/// </summary>
public interface IClubService
{
    /// <summary>
    /// Creates a new club with the given information.
    /// </summary>
    /// <param name="request">Information on the club to create.</param>
    /// <returns>Unique ID of the new club.</returns>
    Task<Guid> CreateClubAsync(CreateClubRequest request);

    /// <summary>
    /// Gets a list of all clubs.
    /// </summary>
    /// <returns>List of all clubs.</returns>
    Task<IReadOnlyList<ClubResponse>> GetClubsAsync();

    /// <summary>
    /// Gets the club with the given ID.
    /// </summary>
    /// <param name="clubId">Unique club ID to search for.</param>
    /// <returns>Information on the club; null if no club matches the given ID.</returns>
    Task<ClubResponse?> GetClubAsync(Guid clubId);

    /// <summary>
    /// Deletes the club with the given ID.
    /// </summary>
    /// <param name="clubId">Unique ID of the club to delete.</param>
    /// <returns></returns>
    Task DeleteClubAsync(Guid clubId);

    Task<IReadOnlyList<ClubKeyResponse>> GetClubKeysAsync();
    
    /// <summary>
    /// Gets all entries associated with this club.
    /// </summary>
    /// <param name="clubId"></param>
    /// <returns></returns>
    Task<ClubEntriesResponse> GetClubEntriesAsync(Guid clubId);
}