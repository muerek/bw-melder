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

namespace BwMelder.Pages.Races
{
    public class EditModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public EditModel(BwMelderDbContext db)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Attach(Race).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RaceExistsAsync(Race.Id))
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

        private async Task<bool> RaceExistsAsync(int id) => await db.Races.AnyAsync(e => e.Id == id);
    }
}
