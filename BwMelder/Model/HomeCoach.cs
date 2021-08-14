using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    /// <summary>
    /// Home coach responsible for a crew before and after the event.
    /// </summary>
    public class HomeCoach
    {
        public Guid Id { get; set; } = Guid.Empty;
        
        [Display(Name = "Vorname")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Nachname")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Name")]
        public string FullName => FirstName + " " + LastName;

        public Contact Contact { get; set; } = new();

        public Guid CrewId { get; set; } = Guid.Empty;
    }
}
