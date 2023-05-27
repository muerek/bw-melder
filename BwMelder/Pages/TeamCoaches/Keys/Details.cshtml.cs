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

namespace BwMelder.Pages.TeamCoaches.Keys
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

        public TeamCoachKey? Key { get; set; }
        public string BaseUrl { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Key = await db.TeamCoachKeys
                .AsNoTracking()
                .SingleOrDefaultAsync(key => key.Id == id);

            if (Key == null)
            {
                return NotFound();
            }

            // Base URL is needed for generating the secret URLs team coaches are supposed to use.
            BaseUrl = httpContextAccessor.HttpContext?.Request.BaseUrl() ?? string.Empty;

            return Page();
        }

        public string GetSecretUrl(TeamCoachKey key) => $"{BaseUrl}TeamCoaches/Key/{key.Secret}";
    }
}
