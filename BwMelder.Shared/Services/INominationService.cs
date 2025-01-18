using BwMelder.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Services;

/// <summary>
/// Describes a service to process nominations.
/// This includes creating a crew and any other required steps.
/// </summary>
public interface INominationService
{
    /// <summary>
    /// Processes a nomination for an existing club.
    /// </summary>
    /// <param name="crew">Crew to nominate.</param>
    /// <returns>Unique ID of the nominated crew.</returns>
    Task<Guid> NominateAsync(CreateCrewRequest crew);

    /// <summary>
    /// Processes a nomination for a new club.
    /// </summary>
    /// <param name="crew">Crew to nominate. The club will be replaced with the new club.</param>
    /// <param name="club">Club to create.</param>
    /// <returns>Unique ID of the nominated crew.</returns>
    Task<Guid> NominateAsync(CreateCrewRequest crew, CreateClubRequest club);
}
