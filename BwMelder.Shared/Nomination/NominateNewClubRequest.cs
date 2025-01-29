using BwMelder.Shared.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Nomination;

public class NominateNewClubRequest
{
    [Required, NotDefault]
    public int RaceId { get; set; } = 0;

    [ValidateComplexType]
    public CreateClubRequest NewClub { get; set; } = new();
}
