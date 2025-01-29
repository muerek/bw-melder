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

public class NominationService(IClubService clubService, BwMelderDbContext db)
    : INominationService
{
    public async Task<Guid> NominateAsync(NominateExistingClubRequest nomination)
    {
        var crew = new Crew
        {
            ClubId = nomination.ClubId,
            RaceId = nomination.RaceId
        };

        db.Crews.Add(crew);
        await db.SaveChangesAsync();

        return crew.Id;
    }

    public async Task<Guid> NominateAsync(NominateNewClubRequest nomination)
    {
        var clubId = await clubService.CreateClubAsync(nomination.NewClub);
        var crew = new NominateExistingClubRequest
        {
            ClubId = clubId,
            RaceId = nomination.RaceId
        };
        return await NominateAsync(crew);
    }
}
