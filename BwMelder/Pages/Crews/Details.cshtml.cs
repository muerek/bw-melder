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
    public class DetailsModel : PageModel
    {
        private readonly BwMelderDbContext _context;

        public DetailsModel(BwMelderDbContext context)
        {
            _context = context;
        }

        public Crew Crew { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Crew = await _context.Crews
                .AsNoTracking()
                .Include(c => c.HomeCoach)
                .Include(c => c.Race)
                .Include(c => c.Athletes)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Crew == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
