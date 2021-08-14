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

namespace BwMelder.Pages.Crews.Athletes
{
    public class CreateModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public CreateModel(BwMelderDbContext context)
        {
            db = context;
        }

        /// <summary>
        /// Handler for GET requests, prepares the form for a new athlete.
        /// </summary>
        /// <param name="crewId">GUID of the crew this athlete belongs to.</param>
        /// <param name="isCox">Optional flag if this athlete is a cox.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(Guid crewId, bool? isCox)
        {
            // Try to find the referenced crew.
            Crew = await db.Crews
                .AsNoTracking()
                .Include(c => c.Race)
                .SingleOrDefaultAsync(c => c.Id == crewId);
            
            // Do not proceed if crew could not be found.
            if (Crew == null)
            {
                return BadRequest();
            }

            // Assign the new athlete to the crew.
            Athlete.CrewId = crewId;
            
            if (isCox != null)
            {
                Athlete.IsCox = (bool)isCox;
            }
            
            return Page();
        }

        [BindProperty]
        public Athlete Athlete { get; set; } = new();
        
        public Crew? Crew { get; set; } = null;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            db.Athletes.Add(Athlete);
            await db.SaveChangesAsync();

            // Cannot use double-dot to go to parent folder here.
            return RedirectToPage("/Crews/Details", new { id = Athlete.CrewId });
        }
    }
}
