using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Races
{
    public class DeleteModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DeleteModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Race Race { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Race = await db.Races
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (Race == null)
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

            Race = await db.Races.FindAsync(id);

            if (Race != null)
            {
                db.Races.Remove(Race);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
