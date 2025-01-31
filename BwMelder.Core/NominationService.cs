using BwMelder.Core.Data;
using BwMelder.Core.Model;
using BwMelder.Shared.Clubs;
using BwMelder.Shared.Crews;
using BwMelder.Shared.Nomination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Core;

public class NominationService(IClubService clubService, ICrewService crewService)
    : INominationService
{
    public async Task<Guid> NominateAsync(NominateExistingClubRequest nomination)
    {
        var createCrewRequest = new CreateCrewRequest
        {
            ClubId = nomination.ClubId,
            RaceId = nomination.RaceId
        };
        return await crewService.CreateCrewAsync(createCrewRequest);
    }

    public async Task<Guid> NominateAsync(NominateNewClubRequest nomination)
    {
        var createClubRequest = new CreateClubRequest { Name = nomination.ClubName };
        var clubId = await clubService.CreateClubAsync(createClubRequest);
        var crew = new NominateExistingClubRequest
        {
            ClubId = clubId,
            RaceId = nomination.RaceId
        };
        return await NominateAsync(crew);
    }
}
