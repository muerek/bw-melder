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

        public TeamCoachKey? Key { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid secret)
        {
            Key = await db.TeamCoachKeys
                .AsNoTracking()
                .Include(key => key.TeamCoach)
                .SingleOrDefaultAsync(key => key.Secret == secret);

            // Cancel if an invalid key was presented.
            if (Key == null)
            {
                return BadRequest();
            }

            // Go to existing team coach if one is already attached to that key.
            if (Key.TeamCoach != null)
            {
                return RedirectToPage("./Details", new { id = Key.TeamCoach.Id });
            }

            // Display page if key is valid and unused.
            return Page();
        }
    }
}
