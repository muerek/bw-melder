using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Reports
{
    public class AthletesModel : PageModel
    {
        private readonly BwMelder.Data.BwMelderDbContext db;

        public AthletesModel(BwMelder.Data.BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<Crew> Crews { get; set; }

        public async Task OnGetAsync()
        {
            Crews = await db.Crews
                .AsNoTracking()
                .Include(c => c.Race)
                .Include(c => c.Athletes)
                .Include(c => c.HomeCoach)
                .OrderBy(c => c.Race.Number.Length)
                .ThenBy(c => c.Race.Number)
                .ToListAsync();
        }
    }
}
