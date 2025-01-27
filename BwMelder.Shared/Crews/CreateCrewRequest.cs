using BwMelder.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Crews;

public class CreateCrewRequest
{
    [Required, NotDefault]
    public Guid ClubId { get; set; } = Guid.Empty;

    [Required, NotDefault]
    public int RaceId { get; set; } = 0;
}
