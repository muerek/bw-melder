using BwMelder.Core.Data;
using BwMelder.Shared.Races;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Core;

public class RaceService(BwMelderDbContext db)
    : IRaceService
{
    public async Task<IList<RaceSummaryResponse>> GetRacesAsync()
    {
        return await db.Races
            .AsNoTracking()
            .Select(r => new RaceSummaryResponse
            {
                Id = r.Id,
                DisplayName = r.FullName
            })
            .ToListAsync();
    }
}
