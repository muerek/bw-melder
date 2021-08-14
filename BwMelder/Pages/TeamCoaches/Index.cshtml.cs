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
    public class IndexModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public IndexModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<TeamCoach> TeamCoaches { get; set; }

        public async Task OnGetAsync()
        {
            TeamCoaches = await db.TeamCoaches
                .AsNoTracking()
                .OrderBy(tc => tc.LastName)
                .ToListAsync();
        }
    }
}
