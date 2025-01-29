using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Nomination;

public class NominateExistingClubRequest
{
    [Required, NotDefault]
    public Guid ClubId { get; set; } = Guid.Empty;

    [Required, NotDefault]
    public int RaceId { get; set; } = 0;
}
