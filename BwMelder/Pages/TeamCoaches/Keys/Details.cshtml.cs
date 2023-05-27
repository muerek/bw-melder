using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.TeamCoaches.Keys
{
    public class DetailsModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DetailsModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public TeamCoachKey? Key { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Key = await db.TeamCoachKeys
                .AsNoTracking()
                .SingleOrDefaultAsync(key => key.Id == id);

            if (Key == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
