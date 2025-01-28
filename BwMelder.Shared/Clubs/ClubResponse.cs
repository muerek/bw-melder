using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Clubs;

public class ClubResponse
{
    /// <summary>
    /// Database ID of the club.
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Name of the club.
    /// </summary>
    public required string Name { get; set; }
}
