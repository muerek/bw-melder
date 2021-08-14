using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BwMelder.Data;
using BwMelder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Pages.Reports
{
    public class ShirtOrderModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public ShirtOrderModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<(ShirtSize Size, int Count)> AthleteShirtOrder { get; set; }

        public IList<(ShirtSize Size, int Count)> TeamCoachShirtOrder { get; set; }

        public async Task OnGetAsync()
        {
            AthleteShirtOrder = await db.Athletes
                .AsNoTracking()
                .GroupBy(a => a.ShirtSize)
                .Select(g => new ValueTuple<ShirtSize, int>(g.Key, g.Count()))
                .ToListAsync();

            TeamCoachShirtOrder = await db.TeamCoaches
                .AsNoTracking()
                .GroupBy(tc => tc.ShirtSize)
                .Select(g => new ValueTuple<ShirtSize, int>(g.Key, g.Count()))
                .ToListAsync();
        }
    }
}
