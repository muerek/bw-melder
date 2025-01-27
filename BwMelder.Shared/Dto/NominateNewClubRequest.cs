using BwMelder.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Dto;

public class NominateNewClubRequest
{
    [Required, NotDefault]
    public int RaceId { get; set; } = 0;

    [ValidateComplexType]
    public CreateClubRequest NewClub { get; set; } = new();
}
