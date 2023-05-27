using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BwMelder.Data;
using BwMelder.Model;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Pages.TeamCoaches
{
    public class CreateModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public CreateModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> OnGetAsync(Guid? secret)
        {
            // Check for a valid key.
            if (secret != null)
            {
                var key = await db.TeamCoachKeys
                    .AsNoTracking()
                    .SingleOrDefaultAsync(key => key.Secret == secret);

                if (key != null)
                {
                    // Attach key to new team coach entry so the key cannot be used for another new entry.
                    // Must be done for authenticated users as well to ensure data consistency.
                    TeamCoach.TeamCoachKeyId = key.Id;
                    return Page();
                }
            }

            // Authenticated users are allowed to create team coaches without a key.
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return Page();
            }

            // Fail for unauthenticated users without key or with invalid key.
            return Forbid();
        }

        [BindProperty]
        public TeamCoach TeamCoach { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // If a key is already attached, make sure it is still valid and the right one.
            if (TeamCoach.TeamCoachKeyId != null)
            {
                var key = await db.TeamCoachKeys
                    .AsNoTracking()
                    .FirstOrDefaultAsync(key => key.Id == TeamCoach.TeamCoachKeyId);

                if (key == null)
                {
                    // TODO: Change to meaningful error message.
                    return BadRequest();
                }
            }
            // If the key is not yet set, generate and save a new key.
            else
            {
                var key = new TeamCoachKey
                {
                    Comment = $"Generated for {TeamCoach.FullName} at {DateTime.Now.ToString()}"
                };
                db.TeamCoachKeys.Add(key);
                TeamCoach.TeamCoachKey = key;
            }

            db.TeamCoaches.Add(TeamCoach);
            await db.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = TeamCoach.Id });
        }
    }
}
