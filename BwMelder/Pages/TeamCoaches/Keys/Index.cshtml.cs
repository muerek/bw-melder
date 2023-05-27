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
    public class IndexModel : PageModel
    {
        private readonly BwMelderDbContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public IndexModel(BwMelderDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        public IList<TeamCoachKey> TeamCoachKeys { get; set; } = new List<TeamCoachKey>();

        public string BaseUrl { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            TeamCoachKeys = await db.TeamCoachKeys
                .AsNoTracking()
                .Where(key => key.TeamCoach == null)
                .ToListAsync();

            BaseUrl = httpContextAccessor.HttpContext?.Request.BaseUrl() ?? string.Empty;
        }

        public string GetSecretUrl(TeamCoachKey key) => $"{BaseUrl}TeamCoaches/Key/{key.Secret}";
    }
}
