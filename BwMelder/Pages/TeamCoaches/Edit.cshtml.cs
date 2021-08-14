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

namespace BwMelder.Pages.TeamCoaches
{
    public class EditModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public EditModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public TeamCoach TeamCoach { get; set; }

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(TeamCoach).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TeamCoachExistsAsync(TeamCoach.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", new { id = TeamCoach.Id });
        }

        private async Task<bool> TeamCoachExistsAsync(Guid id) => await db.TeamCoaches.AnyAsync(e => e.Id == id);
    }
}
