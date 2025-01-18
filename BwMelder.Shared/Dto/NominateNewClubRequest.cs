using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Dto;

public class NominateNewClubRequest
{
    public int RaceId { get; set; } = 0;

    public CreateClubRequest NewClub { get; set; } = new();
}
