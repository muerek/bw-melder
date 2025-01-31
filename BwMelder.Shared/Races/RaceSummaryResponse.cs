using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Races;

/// <summary>
/// A service response with brief information on a race.
/// </summary>
public class RaceSummaryResponse
{
    public required int Id { get; set; }

    public required string DisplayName { get; set; }
}
