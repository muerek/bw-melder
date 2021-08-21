using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    public class Athlete : Participant
    {
        [Display(Name = "Erziehungsberechtigter")]
        public LegalGuardian LegalGuardian { get; set; } = new();

        [Display(Name = "Steuermensch")]
        public bool IsCox { get; set; } = false;

        public Guid CrewId { get; set; } = Guid.Empty;
    }
}
