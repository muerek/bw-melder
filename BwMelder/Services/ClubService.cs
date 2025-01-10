using BwMelder.Data;
using BwMelder.Dto;
using BwMelder.Model;

namespace BwMelder.Services;

class ClubService(BwMelderDbContext db)
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
