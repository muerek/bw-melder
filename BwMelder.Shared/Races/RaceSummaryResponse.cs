using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Races;

/// <summary>
/// A service response with brief information on a race.
/// </summary>
public record RaceSummaryResponse
{
    /// <summary>
    /// Unique ID assigned to this race in the database.
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// Race number as referenced in official documents.
    /// </summary>
    public required string Number { get; init; }

    /// <summary>
    /// Descriptive name of the race.
    /// </summary>
    public required string Name { get; init; }
}
