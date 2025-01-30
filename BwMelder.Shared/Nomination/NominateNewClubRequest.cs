using BwMelder.Shared.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Nomination;

/// <summary>
/// A request to nominate a new club for an open spot in a race.
/// </summary>
public class NominateNewClubRequest
{
    [Required, NotDefault]
    public int RaceId { get; set; } = 0;

    [ValidateComplexType]
    public CreateClubRequest NewClub { get; set; } = new();
}
