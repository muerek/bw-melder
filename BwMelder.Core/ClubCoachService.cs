using BwMelder.Core.Data;
using BwMelder.Core.Model;
using BwMelder.Shared.ClubCoaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BwMelder.Shared.Common;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Core;

public class ClubCoachService(BwMelderDbContext db)
    : IClubCoachService
{
    public async Task CreateClubCoachAsync(CreateClubCoachRequest request)
    {
        var clubCoach = new ClubCoach()
        {
            Name = new Name
            {
                First = request.FirstName,
                Last = request.LastName
            },
            Contact = new Contact
            {
                Phone = request.Contact.Phone,
                EmailAddress = request.Contact.EmailAddress
            },
            ClubId = request.ClubId
        };

        await db.ClubCoaches.AddAsync(clubCoach);
        await db.SaveChangesAsync();
    }

    public async Task<ClubCoachResponse?> GetClubCoachAsync(Guid clubId)
    {
        return await db.ClubCoaches
            .AsNoTracking()
            .Where(c => c.ClubId == clubId)
            .Select(c => new ClubCoachResponse
            {
                Id = c.Id,
                Name = c.Name.Full,
                Contact = new ContactResponse
                {
                    Phone = c.Contact.Phone,
                    EmailAddress = c.Contact.EmailAddress,
                },
            })
            .SingleOrDefaultAsync();
    }
}
