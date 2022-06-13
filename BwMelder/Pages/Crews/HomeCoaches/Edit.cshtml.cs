using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Crews.HomeCoaches
{
    public class EditModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public EditModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public HomeCoach HomeCoach { get; set; }
        public Crew? Crew { get; set; }

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Update(HomeCoach);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await db.HomeCoaches.AnyAsync(e => e.Id == HomeCoach.Id))
                {
                    throw;
                }
                else
                {
                    return NotFound();
                }
            }

            return RedirectToPage("/Crews/Details", new { id = HomeCoach.CrewId });
        }
    }
}
