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
    public async Task<IReadOnlyList<ClubCrewResponse>> GetCrewsByClubAsync(Guid clubId)
    {
        return await db.Crews
            .Where(c => c.ClubId == clubId)
            .Include(c => c.Race)
            .Select(c => new ClubCrewResponse
            {
                CrewId = c.Id,
                RegistrationProgress = new RegistrationProgressResponse
                {
                    CurrentAthleteCount = c.Athletes.Count,
                    TargetAthleteCount = c.Race.AthleteCount
                },
                Race = new RaceSummaryResponse
                {
                    Id = c.Race.Id,
                    Number = c.Race.Number,
                    Name = c.Race.Name
                }
            })
            .ToListAsync();
    }

    public async Task<Guid> CreateCrewAsync(CreateCrewRequest request)
    {
        var crew = new Crew
        {
            ClubId = request.ClubId,
            RaceId = request.RaceId
        };

        await db.Crews.AddAsync(crew);
        await db.SaveChangesAsync();
        return crew.Id;
    }

    public async Task<IReadOnlyList<CrewResponse>> GetAllCrewsAsync()
    {
        // TODO: Use split queries here?
        return await db.Crews
            .AsNoTracking()
            .Include(c => c.Race)
            .Include(c => c.Club)
            .Include(c => c.Athletes)
            .Select(c => new CrewResponse
            {
                CrewId = c.Id,
                Club = new ClubResponse
                {
                    Id = c.Club.Id,
                    Name = c.Club.Name
                },
                Race = new RaceSummaryResponse
                {
                    Id = c.Race.Id,
                    Number = c.Race.Number,
                    Name = c.Race.Name
                },
                RegistrationProgress = new RegistrationProgressResponse
                {
                    CurrentAthleteCount = c.Athletes.Count,
                    TargetAthleteCount = c.Race.AthleteCount
                }
            })
            .ToListAsync();
    }
}
