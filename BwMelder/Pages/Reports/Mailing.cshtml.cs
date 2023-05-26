using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Pages.Reports
{
    public class MailingModel : PageModel
    {
        private readonly BwMelder.Data.BwMelderDbContext db;

        public MailingModel(BwMelder.Data.BwMelderDbContext db)
        {
            this.db = db;
        }

        public IList<string> TeamCoachEmailAddresses { get; set; } = new List<string>();
        public IList<string> HomeCoachEmailAddresses { get; set; } = new List<string>();

        public IList<string> AllEmailAddresses => TeamCoachEmailAddresses.Concat(HomeCoachEmailAddresses).Distinct().ToList();

        public async Task OnGetAsync()
        {
            TeamCoachEmailAddresses = await db.TeamCoaches
                .AsNoTracking()
                .Select(tc => tc.Contact.EmailAddress)
                .Distinct()
                .ToListAsync();

            HomeCoachEmailAddresses = await db.HomeCoaches
                .AsNoTracking()
                .Select(hc => hc.Contact.EmailAddress)
                .Distinct()
                .ToListAsync();
        }

        /// <summary>
        /// Generates a mailto link addressing all given addresses as Bcc recipients.
        /// </summary>
        /// <param name="emailAddresses">List of email addresses.</param>
        /// <returns>Mailto link to send an email to all addresses as Bcc recipients.</returns>
        public string GetMailtoLink(IList<string> emailAddresses)
        {
            return "mailto:?bcc=" + string.Join(",", emailAddresses);
        }
    }
}
