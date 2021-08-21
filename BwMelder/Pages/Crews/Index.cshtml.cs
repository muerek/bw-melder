using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Crews
{
    public class IndexModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public IndexModel(BwMelderDbContext context)
        {
            db = context;
        }

        public IList<Crew> Crews { get;set; }

        public async Task OnGetAsync()
        {
            Crews = await db.Crews
                .AsNoTracking()
                .Include(c => c.HomeCoach)
                .Include(c => c.Race)
                .Include(c => c.Athletes)
                .OrderBy(c => c.Race.Number.Length)
                .ThenBy(c => c.Race.Number)
                .ToListAsync();
        }
    }
}
