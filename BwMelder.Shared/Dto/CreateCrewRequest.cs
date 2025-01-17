using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Dto;

public class CreateCrewRequest
{
    public Guid ClubId { get; set; } = Guid.Empty;

    public int RaceId { get; set; } = 0;
}
