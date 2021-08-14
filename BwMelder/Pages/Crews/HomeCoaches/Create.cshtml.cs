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

namespace BwMelder.Pages.Crews.HomeCoaches
{
    public class CreateModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public CreateModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> OnGetAsync(Guid crewId)
        {
            Crew = await db.Crews
                .AsNoTracking()
                .Include(c => c.Race)
                .SingleOrDefaultAsync(c => c.Id == crewId);

            if (Crew == null)
            {
                return BadRequest();
            }

            HomeCoach.CrewId = crewId;
            return Page();
        }

        [BindProperty]
        public HomeCoach HomeCoach { get; set; } = new();
        public Crew? Crew { get; set; } = null;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.HomeCoaches.Add(HomeCoach);
            await db.SaveChangesAsync();

            return RedirectToPage("/Crews/Details", new { id = HomeCoach.CrewId });
        }
    }
}
