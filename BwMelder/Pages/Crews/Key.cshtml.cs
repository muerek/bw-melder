using BwMelder.Data;
using BwMelder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Pages.Crews
{
    public class KeyModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public KeyModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public Crew? Crew { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid secret)
        {
            Crew = await db.Crews
                .AsNoTracking()
                .Include(c => c.Race)
                .SingleOrDefaultAsync(c => c.Id == secret);

            // Cancel if an invalid key was presented.
            if (Crew == null)
            {
                return BadRequest();
            }

            // Check if any data was added to this crew already.
            // Not loading the navigation properties above to avoid a large join operation.
            // The simple count should be much easier on the database.

            var athleteCount = await db.Athletes
                .AsNoTracking()
                .Where(a => a.CrewId == Crew.Id)
                .CountAsync();

            var homeCoachCount = await db.HomeCoaches
                .AsNoTracking()
                .Where(a => a.CrewId == Crew.Id)
                .CountAsync();

            // Go directly to crew entry if any data has been added already.
            if (athleteCount + homeCoachCount > 0)
            {
                return RedirectToPage("./Details", new { id = Crew.Id });
            }

            // Display page for a crew entry without any data.
            return Page();
        }
    }
}
