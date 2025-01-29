using BwMelder.Core.Data;
using BwMelder.Core.Model;
using BwMelder.Shared.Clubs;
using BwMelder.Shared.Crews;
using BwMelder.Shared.Races;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Core;

public class CrewService(BwMelderDbContext db) : ICrewService
{
    public async Task<IList<CrewStatusResponse>> GetCrewStatusesAsync()
    {
        return await db.Crews
            .AsNoTracking()
            .Include(c => c.Race)
            .Include(c => c.Club)
            .Include(c => c.Athletes)
            .Select(c => new CrewStatusResponse
            {
                Club = new ClubResponse
                {
                    Id = c.Club.Id,
                    Name = c.Club.Name
                },
                Race = new RaceResponse
                {
                    Id = c.Race.Id,
                    Name = c.Race.Name,
                    RowerCount = c.Race.RowerCount,
                    Coxed = c.Race.Coxed,
                    Number = c.Race.Number
                },
                RegisteredAthletes = c.Athletes.Count
            })
            .ToListAsync();
    }
}
