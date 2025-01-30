using BwMelder.Shared.Clubs;
using BwMelder.Shared.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Crews;

/// <summary>
/// A service response summarizing the current status of a crew.
/// </summary>
public class CrewStatusResponse
{
    public required Guid CrewId { get; set; }

    public required RaceSummaryResponse Race { get; set; }

    public required ClubResponse Club { get; set; }

    /// <summary>
    /// Number of athletes that have been registered for this crew.
    /// </summary>
    public required int CurrentAthleteCount { get; set; }

    /// <summary>
    /// Number of athletes that must be registered to complete the crew.
    /// </summary>
    public required int TargetAthleteCount { get; set; }
}
