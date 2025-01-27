using BwMelder.Core.Model;
using BwMelder.Shared.Crews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Core;

public class CrewService(BwMelderDbContext db) : ICrewService
{
    public async Task<Guid> CreateCrewAsync(CreateCrewRequest request)
    {
        var crew = new Crew
        {
            ClubId = request.ClubId,
            RaceId = request.RaceId
        };

        db.Crews.Add(crew);
        await db.SaveChangesAsync();

        return crew.Id;
    }
}
