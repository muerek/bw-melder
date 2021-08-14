using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Races
{
    public class CreateModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public CreateModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Race Race { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Races.Add(Race);
            await db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
