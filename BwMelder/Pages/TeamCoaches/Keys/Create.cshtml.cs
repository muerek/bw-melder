using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.TeamCoaches.Keys
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
        public TeamCoachKey Key { get; set; } = new();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrEmpty(Key.Comment))
            {
                Key.Comment = $"Generated at {DateTime.Now.ToString()}";
            }

            db.TeamCoachKeys.Add(Key);
            await db.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = Key.Id });
        }
    }
}
