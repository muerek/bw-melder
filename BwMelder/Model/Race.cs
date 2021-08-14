using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    public class Race
    {
        public int Id { get; set; } = 0;
        
        /// <summary>
        /// Race number as referenced in official documents.
        /// </summary>
        /// <remarks>May not only be numeric.</remarks>
        [Display(Name = "Rennnummer")]
        public string Number { get; set; } = string.Empty;

        /// <summary>
        /// Full name of the race.
        /// </summary>
        [Display(Name = "Bezeichnung")]
        public string Name { get; set; } = string.Empty;

        public string FullName => $"{Number} - {Name}";

        /// <summary>
        /// Total number of rowers per crew in this race.
        /// </summary>
        /// <remarks>
        /// Does not include coxes. Check <see cref="AthleteCount"/> to account for coxes as well.
        /// </remarks>
        [Display(Name = "Anzahl Ruderer je Mannschaft")]
        [Range(1, 5)]
        public int RowerCount { get; set; } = 1;

        [Display(Name = "Steuermensch")]
        public bool Coxed { get; set; } = false;

        /// <summary>
        /// Total number of athletes per crew in this race.
        /// Athletes are both rowers and, if applicable, coxes.
        /// </summary>
        [Display(Name = "Anzahl Sportler je Mannschaft")]
        public int AthleteCount => RowerCount + (Coxed ? 1 : 0);

        public virtual IList<Crew> Crews { get; set; } = new List<Crew>();
    }
}
