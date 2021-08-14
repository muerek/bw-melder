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

namespace BwMelder.Pages.Crews
{
    public class EditModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public EditModel(BwMelderDbContext db)
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
                .SingleOrDefaultAsync(m => m.Id == id);

            if (Crew == null)
            {
                return NotFound();
            }

            ViewData["RaceId"] = new SelectList(
                db.Races.OrderBy(r => r.Number.Length).ThenBy(r => r.Number),
                "Id",
                "FullName");

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

            db.Attach(Crew).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CrewExistsAsync(Crew.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> CrewExistsAsync(Guid id) => await db.Crews.AnyAsync(e => e.Id == id);
    }
}
