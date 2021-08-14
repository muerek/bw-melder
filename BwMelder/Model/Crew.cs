using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    public class Crew
    {
        [Display(Name = "Schlüssel")]
        public Guid Id { get; set; } = Guid.Empty;

        [Display(Name = "Verein")]
        public string ClubName { get; set; } = string.Empty;

        [Display(Name = "Rennen")]
        [ValidateNever]
        public virtual Race Race { get; set; } = null!;
        public int RaceId { get; set; } = 0;

        [Display(Name = "Sportler")]
        [ValidateNever]
        public virtual List<Athlete> Athletes { get; set; } = null!;

        [Display(Name = "Heimtrainer")]
        public virtual HomeCoach? HomeCoach { get; set; } = null;
    }
}
