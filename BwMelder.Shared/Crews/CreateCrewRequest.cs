using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Crews;

/// <summary>
/// A request to create a crew.
/// </summary>
public class CreateCrewRequest
{
    [Required, NotDefault]
    public Guid ClubId { get; set; } = default;

    [Required, NotDefault]
    public int RaceId { get; set; } = 0;
}
