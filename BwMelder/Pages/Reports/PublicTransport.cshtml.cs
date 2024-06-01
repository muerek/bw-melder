using BwMelder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BwMelder.Pages.Reports
{
    public class PublicTransportModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public PublicTransportModel(BwMelder.Data.BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<(bool HasTicket, int Count)> AthleteTickets = new List<(bool HasTicket, int Count)>();

        public IList<(bool HasTicket, int Count)> TeamCoachTickets = new List<(bool HasTicket, int Count)>();

        public async void OnGetAsync()
        {
            AthleteTickets = await db.Athletes
                .AsNoTracking()
                .GroupBy(a => a.HasPublicTransportTicket)
                .Select(g => new ValueTuple<bool, int>(g.Key, g.Count()))
                .ToListAsync();

            TeamCoachTickets = await db.TeamCoaches
                .AsNoTracking()
                .GroupBy(tc => tc.HasPublicTransportTicket)
                .Select(g => new ValueTuple<bool, int>(g.Key, g.Count()))
                .ToListAsync();
        }
    }
}
