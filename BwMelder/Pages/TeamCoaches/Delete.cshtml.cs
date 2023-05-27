using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.TeamCoaches
{
    public class DeleteModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DeleteModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public TeamCoach? TeamCoach { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            TeamCoach = await db.TeamCoaches
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (TeamCoach == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamCoach = await db.TeamCoaches.FindAsync(id);

            if (TeamCoach != null)
            {
                db.TeamCoaches.Remove(TeamCoach);

                // Check for an attached key and delete it too.
                if (TeamCoach.TeamCoachKeyId != null)
                {
                    var key = await db.TeamCoachKeys.FindAsync(TeamCoach.TeamCoachKeyId);
                    if (key != null)
                    {
                        db.TeamCoachKeys.Remove(key);
                    }
                }

                await db.SaveChangesAsync();
            }

            // Return authenticated users to the overview, anonymous users to the homepage.
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToPage("./Index");
            }
            return RedirectToPage("/");
        }
    }
}
