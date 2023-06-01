using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BwMelder.Data;
using BwMelder.Model;
using Microsoft.AspNetCore.Http;
using BwMelder.Extensions;

namespace BwMelder.Pages.Crews
{
    public class DetailsModel : PageModel
    {
        private readonly BwMelderDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DetailsModel(BwMelderDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Crew? Crew { get; set; }
        public string BaseUrl { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Crew = await db.Crews
                .AsNoTracking()
                .Include(c => c.HomeCoach)
                .Include(c => c.Race)
                .Include(c => c.Athletes)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (Crew == null)
            {
                return NotFound();
            }

            BaseUrl = httpContextAccessor.HttpContext?.Request.BaseUrl() ?? string.Empty;

            return Page();
        }

        public string GetSecretUrl() => $"{BaseUrl}Crews/Key/{Crew?.Id}";
    }
}
