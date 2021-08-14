using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    public enum DriversLicense
    {
        [Display(Name = "Kein Führerschein")]
        None = 0,
        [Display(Name = "PKW (B oder gleichwertig)")]
        Car = 1,
        [Display(Name = "Anhänger (BE oder gleichwertig)")]
        Trailer = 2
    }
}
