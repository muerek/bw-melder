using BwMelder.Shared.Dto;
using BwMelder.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Core;

public class NominationService(IClubService clubService, ICrewService crewService)
    : INominationService
{
    public async Task<Guid> NominateAsync(CreateCrewRequest nomination)
    {
        return await crewService.CreateCrewAsync(nomination);
    }

    public async Task<Guid> NominateAsync(NominateNewClubRequest nomination)
    {
        var clubId = await clubService.CreateClubAsync(nomination.NewClub);
        var crew = new CreateCrewRequest
        {
            ClubId = clubId,
            RaceId = nomination.RaceId
        };
        return await NominateAsync(crew);
    }
}
