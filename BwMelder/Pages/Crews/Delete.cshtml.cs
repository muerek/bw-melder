using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Crews
{
    public class DeleteModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DeleteModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Crew Crew { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Crew = await db.Crews
                .AsNoTracking()
                .Include(c => c.HomeCoach)
                .Include(c => c.Race)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Crew == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            Crew = await db.Crews.FindAsync(id);

            if (Crew != null)
            {
                db.Crews.Remove(Crew);
                await db.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
