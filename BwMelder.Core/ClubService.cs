using BwMelder.Shared.Dto;
using BwMelder.Core.Model;
using BwMelder.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Core;

public class ClubService(BwMelderDbContext db)
    : IClubService
{
    public async Task<Guid> CreateClubAsync(CreateClubRequest request)
    {
        var club = new Club()
        {
            Name = request.Name
        };

        db.Clubs.Add(club);
        await db.SaveChangesAsync();
        return club.Id;
    }

    public async Task DeleteClubAsync(Guid clubId)
    {
        await db.Clubs
            .Where(c => c.Id == clubId)
            .ExecuteDeleteAsync();
    }

    public async Task<ClubResponse?> GetClubAsync(Guid clubId)
    {
        return await db.Clubs
            .AsNoTracking()
            .Select(c => new ClubResponse
            { Id = c.Id, Name = c.Name })
            .SingleOrDefaultAsync();
    }

    public async Task<IList<ClubResponse>> GetClubsAsync()
    {
        return await db.Clubs
            .AsNoTracking()
            .Select(c => new ClubResponse { Id = c.Id, Name = c.Name })
            .ToListAsync();
    }
}
