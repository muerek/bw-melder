using BwMelder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BwMelder.Pages.Reports
{
    public class EntriesModel : PageModel
    {
        private readonly BwMelder.Data.BwMelderDbContext db;

        public EntriesModel(BwMelder.Data.BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<Race> Races { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Entries are printed by race, therefore we start loading data from there.
            Races = await db.Races
                .AsNoTracking()
                .Include(r => r.Crews)
                .ThenInclude(c => c.Athletes)
                .OrderBy(r => r.Number.Length)
                .ThenBy(r => r.Number)
                .ToListAsync();

            // Should return at least an empty list, but make sure it really did.
            if (Races == null)
            {
                return StatusCode(500);
            }

            return Page();
        }
    }
}
