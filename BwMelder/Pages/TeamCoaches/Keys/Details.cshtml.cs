using BwMelder.Data;
using BwMelder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BwMelder.Pages.TeamCoaches.Keys
{
    public class DetailsModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public DetailsModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public TeamCoachAccessKey AccessKey { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            AccessKey = await db.TeamCoachAccessKeys
                .AsNoTracking()
                .SingleOrDefaultAsync(ak => ak.Id == id);

            if (AccessKey == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
