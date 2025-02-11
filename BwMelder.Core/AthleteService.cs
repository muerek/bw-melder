using BwMelder.Core.Data;
using BwMelder.Shared.Athletes;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Core;

public class AthleteService(BwMelderDbContext db)
    : IAthleteService
{
    public async Task<IReadOnlyList<AthleteSummaryResponse>> GetAthletesAsync()
    {
        return await db.Athletes
            .AsNoTracking()
            .Select(a => new AthleteSummaryResponse
            {
                Id = a.Id,
                Name = a.Name.Full,
                Position = EnumMapper.ToCommon(a.Position)
            })
            .ToListAsync();
    }
}