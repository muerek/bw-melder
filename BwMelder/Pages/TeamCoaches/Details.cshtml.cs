using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.TeamCoaches
{
    public class DetailsModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DetailsModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public TeamCoach TeamCoach { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            TeamCoach = await db.TeamCoaches
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (TeamCoach == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
