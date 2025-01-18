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
    public async Task<Guid> NominateAsync(CreateCrewRequest crew)
    {
        return await crewService.CreateCrewAsync(crew);
    }

    public async Task<Guid> NominateAsync(CreateCrewRequest crew, CreateClubRequest club)
    {
        var clubId = await clubService.CreateClubAsync(club);
        crew.ClubId = clubId;
        return await NominateAsync(crew);
    }
}
