using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Races;

/// <summary>
/// Represents a service to manage races.
/// </summary>
public interface IRaceService
{
    /// <summary>
    /// Gets a list of all races.
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<RaceSummaryResponse>> GetRacesAsync();
}
