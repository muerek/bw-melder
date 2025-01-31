using BwMelder.Core.Model;
using Microsoft.EntityFrameworkCore;
using BwMelder.Shared.Clubs;
using BwMelder.Core.Data;
using System.Diagnostics.Tracing;

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

    public async Task<IList<ClubKeyResponse>> GetClubKeysAsync()
    {
        // Fetch club information along with any keys.
        var clubs = await db.Clubs
            .AsNoTracking()
            .Include(c => c.AccessKeys)
            .ToListAsync();
        
        return clubs.Select(c => new ClubKeyResponse
        {
            ClubId = c.Id,
            ClubName = c.Name,
            // There should only be a single valid access key.
            Secret = c.AccessKeys.FirstOrDefault(k => k.IsValid)?.Secret
        }).ToList();
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
