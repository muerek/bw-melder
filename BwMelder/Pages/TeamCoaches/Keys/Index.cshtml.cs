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
    public class IndexModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public IndexModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<TeamCoachKey> TeamCoachKeys { get; set; } = new List<TeamCoachKey>();

        public async Task OnGetAsync()
        {
            TeamCoachKeys = await db.TeamCoachKeys
                .AsNoTracking()
                .Where(key => key.TeamCoach == null)
                .ToListAsync();
        }
    }
}
