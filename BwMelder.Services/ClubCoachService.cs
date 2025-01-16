using BwMelder.Data;
using BwMelder.Data.Model;
using BwMelder.Shared.Dto;
using BwMelder.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Services;

public class ClubCoachService(BwMelderDbContext db)
    : IClubCoachService
{
    public async Task AddClubCoachAsync(ClubCoachRequest request)
    {
        var clubCoach = new ClubCoach()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Contact = new Contact()
            {
                Phone = request.Contact.Phone,
                EmailAddress = request.Contact.EmailAddress
            },
            ClubId = request.ClubId
        };

        await db.ClubCoaches.AddAsync(clubCoach);
        await db.SaveChangesAsync();
    }
}
