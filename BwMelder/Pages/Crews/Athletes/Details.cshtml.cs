using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Crews.Athletes
{
    public class DetailsModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DetailsModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public Athlete? Athlete { get; set; }
        public Crew? Crew { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Athlete = await db.Athletes
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (Athlete == null)
            {
                return NotFound();
            }

            Crew = await db.Crews
                .AsNoTracking()
                .Include(c => c.Race)
                .SingleOrDefaultAsync(c => c.Id == Athlete.CrewId);

            if (Crew == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
