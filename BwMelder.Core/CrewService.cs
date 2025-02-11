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
    public async Task<IReadOnlyList<CrewByClubResponse>> GetCrewsByClubAsync(Guid clubId)
    {
        return await db.Crews
            .Where(c => c.ClubId == clubId)
            .Select(c => new CrewByClubResponse
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

    public async Task<CrewSummaryResponse?> GetCrewAsync(Guid crewId)
    {
        return await db.Crews
            .Where(c => c.Id == crewId)
            .Select(c => new CrewSummaryResponse
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
            .SingleOrDefaultAsync();
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

    public async Task<IReadOnlyList<CrewSummaryResponse>> GetAllCrewsAsync()
    {
        return await db.Crews
            .AsNoTracking()
            .Include(c => c.Race)
            .OrderBy(c => c.Race.Number.Length)
            .ThenBy(c => c.Race.Number)
            .Select(c => new CrewSummaryResponse
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
