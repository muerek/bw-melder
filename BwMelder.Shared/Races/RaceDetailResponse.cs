using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Races;

/// <summary>
/// A service response with full details on a race.
/// </summary>
public class RaceDetailResponse
{
    /// <summary>
    /// Unique ID assigned to this race in the database.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Race number as referenced in official documents.
    /// </summary>
    /// <remarks>May not only be numeric.</remarks>
    public required string Number { get; set; }

    /// <summary>
    /// Descriptive name of the race.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Total number of rowers per crew in this race.
    /// </summary>
    /// <remarks>Does not include coxes.</remarks>
    public required int RowerCount { get; set; }

    /// <summary>
    /// Flag to indicate if crews have a cox in this race.
    /// </summary>
    public required bool Coxed { get; set; }
}
