using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Reports
{
    public class TeamCoachesModel : PageModel
    {
        private readonly BwMelder.Data.BwMelderDbContext db;

        public TeamCoachesModel(BwMelder.Data.BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<TeamCoach> TeamCoach { get;set; }

        public async Task OnGetAsync()
        {
            TeamCoach = await db.TeamCoaches
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
