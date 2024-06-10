using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Crews.HomeCoaches
{
    public class DeleteModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DeleteModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public HomeCoach? HomeCoach { get; set; } = null;

        public Crew? Crew { get; set; } = null;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            HomeCoach = await db.HomeCoaches
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (HomeCoach == null)
            {
                return NotFound();
            }

            Crew = await db.Crews
                .AsNoTracking()
                .Include(c => c.Race)
                .SingleOrDefaultAsync(c => c.Id == HomeCoach.CrewId);

            if (Crew == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            HomeCoach = await db.HomeCoaches.FindAsync(id);

            if (HomeCoach != null)
            {
                db.HomeCoaches.Remove(HomeCoach);
                await db.SaveChangesAsync();

                return RedirectToPage("/Crews/Details", new { id = HomeCoach.CrewId });
            }

            return RedirectToPage("/Crews");
        }
    }
}
