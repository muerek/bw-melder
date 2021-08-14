using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;

namespace BwMelder.Pages.Races
{
    public class IndexModel : PageModel
    {
        private readonly BwMelderDbContext db;

        public IndexModel(BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<Race> Races { get;set; }

        public async Task OnGetAsync()
        {
            // Order by length first, then by value.
            // This helps to sort integer-only race numbers correctly as they are stored as strings.
            Races = await db.Races
                .AsNoTracking()
                .OrderBy(r => r.Number.Length)
                .ThenBy(r => r.Number)
                .ToListAsync();
        }
    }
}
