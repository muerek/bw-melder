using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    /// <summary>
    /// Information on the legal guardian for underage athletes.
    /// </summary>
    [Owned]
    public class LegalGuardian
    {
        [Display(Name = "Vorname")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Nachname")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Name")]
        public string FullName => FirstName + " " + LastName;

        public Contact Contact { get; set; } = new();
    }
}
