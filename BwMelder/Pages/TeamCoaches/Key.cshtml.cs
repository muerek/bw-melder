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
            var teamCoachKey = await db.TeamCoachKeys
                .AsNoTracking()
                .Include(tck => tck.TeamCoach)
                .FirstOrDefaultAsync(tck => tck.Secret == secret);

            // Cancel if an invalid key was presented.
            if (teamCoachKey == null)
            {
                return BadRequest();
            }

            // Go to adding a new team coach if none is attached to that key yet.
            if (teamCoachKey.TeamCoach == null)
            {
                return RedirectToPage("./Create", new { secret });
            }

            // Go to the team coach attached to this key.
            return RedirectToPage("./Details", new { id = teamCoachKey.TeamCoach.Id });
        }
    }
}
