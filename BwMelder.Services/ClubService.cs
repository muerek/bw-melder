using BwMelder.Data;
using BwMelder.Shared.Dto;
using BwMelder.Data.Model;
using BwMelder.Shared.Services;

namespace BwMelder.Services;

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
}
