using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.ClubCoaches;

public interface IClubCoachService
{
    Task CreateClubCoachAsync(CreateClubCoachRequest request);
}
