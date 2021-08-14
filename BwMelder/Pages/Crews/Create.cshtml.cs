using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Crews
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
            ViewData["RaceId"] = new SelectList(
                db.Races.OrderBy(r => r.Number.Length).ThenBy(r => r.Number),
                "Id",
                "FullName");

            return Page();
        }

        [BindProperty]
        public Crew Crew { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Crews.Add(Crew);
            await db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
