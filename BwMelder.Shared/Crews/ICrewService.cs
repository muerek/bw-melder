using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwMelder.Shared.Clubs;

namespace BwMelder.Shared.Crews;

/// <summary>
/// Represents a service to manage crews.
/// </summary>
public interface ICrewService
{
    /// <summary>
    /// Gets a list of all crews.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<CrewSummaryResponse>> GetAllCrewsAsync();
    
    /// <summary>
    /// Gets a list of crews from to the given club.
    /// </summary>
    /// <param name="clubId">Unique ID of the club.</param>
    /// <returns></returns>
    Task<IReadOnlyList<CrewByClubResponse>> GetCrewsByClubAsync(Guid clubId);
    
    /// <summary>
    /// Gets a summary for the referenced crew.
    /// </summary>
    /// <param name="crewId">Unique ID of the crew.</param>
    /// <returns></returns>
    Task<CrewSummaryResponse?> GetCrewAsync(Guid crewId);

    /// <summary>
    /// Creates a crew in the database.
    /// </summary>
    /// <param name="request">A request describing the crew to create.</param>
    /// <returns>Unique ID of the crew.</returns>
    Task<Guid> CreateCrewAsync(CreateCrewRequest request);
}
