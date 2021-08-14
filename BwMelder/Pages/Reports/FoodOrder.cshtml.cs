using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BwMelder.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BwMelder.Pages.Reports
{
    public class FoodOrderModel : PageModel
    {
        private readonly BwMelder.Data.BwMelderDbContext db;

        public FoodOrderModel(BwMelder.Data.BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<(DietaryChoice Choice, int Count)> AthleteFoodOrder { get; set; }

        public IList<(DietaryChoice Choice, int Count)> TeamCoachFoodOrder { get; set; }

        public IList<(string Restriction, int Count)> Restrictions { get; set; }

        public async Task OnGetAsync()
        {
            AthleteFoodOrder = await db.Athletes
                .AsNoTracking()
                .GroupBy(a => a.Diet.Choice)
                .Select(g => new ValueTuple<DietaryChoice, int>(g.Key, g.Count()))
                .ToListAsync();

            TeamCoachFoodOrder = await db.TeamCoaches
                .AsNoTracking()
                .GroupBy(tc => tc.Diet.Choice)
                .Select(g => new ValueTuple<DietaryChoice, int>(g.Key, g.Count()))
                .ToListAsync();

            Restrictions = (await db.Athletes
                .AsNoTracking()
                .Where(a => !string.IsNullOrWhiteSpace(a.Diet.Restrictions))
                .Select(a => a.Diet.Restrictions)
                .ToListAsync())
                .Concat(await db.TeamCoaches
                    .AsNoTracking()
                    .Where(tc => !string.IsNullOrWhiteSpace(tc.Diet.Restrictions))
                    .Select(tc => tc.Diet.Restrictions)
                    .ToListAsync())
                .GroupBy(r => r!.Trim())
                .Select(g => (g.Key, g.Count()))
                .OrderBy(r => r.Key)
                .ToList();
        }
    }
}
