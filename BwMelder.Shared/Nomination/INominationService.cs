using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Nomination;

/// <summary>
/// Describes a service to process nominations.
/// This includes creating a crew and any other required steps.
/// </summary>
public interface INominationService
{
    /// <summary>
    /// Processes a nomination for an existing club.
    /// </summary>
    /// <param name="nomination">Nomination for an existing club to process.</param>
    /// <returns>Unique ID of the nominated crew.</returns>
    Task<Guid> NominateAsync(NominateExistingClubRequest nomination);

    /// <summary>
    /// Processes a nomination for a new club.
    /// </summary>
    /// <param name="nomination">Nomination for a new club to process.</param>
    /// <returns>Unique ID of the nominated crew.</returns>
    Task<Guid> NominateAsync(NominateNewClubRequest nomination);
}
