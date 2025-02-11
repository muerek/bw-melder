using BwMelder.Core.Data;
using BwMelder.Shared.Athletes;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Core;

public class AthleteService(BwMelderDbContext db)
    : IAthleteService
{
    public async Task<IReadOnlyList<AthleteSummaryResponse>> GetAthletesByCrewAsync(Guid crewId)
    {
        return await db.Athletes
            .AsNoTracking()
            .Where(a => a.CrewId == crewId)
            .Select(a => new AthleteSummaryResponse
            {
                Id = a.Id,
                Name = a.Name.Full,
                Position = EnumMapper.ToCommon(a.Position)
            })
            .ToListAsync();
    }
}