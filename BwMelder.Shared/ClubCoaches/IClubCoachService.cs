using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.ClubCoaches;

public interface IClubCoachService
{
    Task CreateClubCoachAsync(CreateClubCoachRequest request);
    
    /// <summary>
    /// Gets the club coach for the club with the given ID.
    /// </summary>
    /// <param name="clubId">ID of the club.</param>
    /// <returns>A service response with information on the club coach.</returns>
    Task<ClubCoachResponse?> GetClubCoachAsync(Guid clubId);
}
