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
    public async Task<IList<RaceResponse>> GetRacesAsync()
    {
        return await db.Races
            .AsNoTracking()
            .Select(r => new RaceResponse
            {
                Id = r.Id,
                Number = r.Number,
                Name = r.Name,
                RowerCount = r.RowerCount,
                Coxed = r.Coxed
            })
            .ToListAsync();
    }
}
