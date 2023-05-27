using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.TeamCoaches.Keys
{
    public class DeleteModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DeleteModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public TeamCoachKey? Key { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Key = await db.TeamCoachKeys
                .AsNoTracking()
                .SingleOrDefaultAsync(key => key.Id == id);

            if (Key == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Key = await db.TeamCoachKeys.FindAsync(id);

            if (Key != null)
            {
                db.TeamCoachKeys.Remove(Key);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
