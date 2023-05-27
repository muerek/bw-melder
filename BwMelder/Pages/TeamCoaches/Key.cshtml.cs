using BwMelder.Data;
using BwMelder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BwMelder.Pages.TeamCoaches
{
    public class KeyModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public KeyModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> OnGetAsync(Guid secret)
        {
            var key = await db.TeamCoachKeys
                .AsNoTracking()
                .Include(key => key.TeamCoach)
                .SingleOrDefaultAsync(key => key.Secret == secret);

            // Cancel if an invalid key was presented.
            if (key == null)
            {
                return BadRequest();
            }

            // Go to adding a new team coach if none is attached to that key yet.
            if (key.TeamCoach == null)
            {
                return RedirectToPage("./Create", new { secret });
            }

            // Go to the team coach attached to this key.
            return RedirectToPage("./Details", new { id = key.TeamCoach.Id });
        }
    }
}
