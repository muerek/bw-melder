using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwMelder.Shared.Clubs;

namespace BwMelder.Shared.Crews;

/// <summary>
/// Represents a service to manage crews.
/// </summary>
public interface ICrewService
{
    Task<IList<CrewResponse>> GetAllCrewsAsync();
    
    Task<IList<ClubCrewResponse>> GetCrewsByClubAsync(Guid clubId);

    Task<Guid> CreateCrewAsync(CreateCrewRequest request);
}
