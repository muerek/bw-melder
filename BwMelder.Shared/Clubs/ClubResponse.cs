using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Clubs;

/// <summary>
/// A service response with details on a club.
/// </summary>
public record ClubResponse
{
    /// <summary>
    /// Database ID of the club.
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// Name of the club.
    /// </summary>
    public required string Name { get; init; }
}
