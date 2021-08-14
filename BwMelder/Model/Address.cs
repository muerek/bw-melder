using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    /// <summary>
    /// Address data made up of street, zip and city.
    /// </summary>
    [Owned]
    public class Address
    {
        [Display(Name = "Anschrift")]
        public string Street { get; set; } = string.Empty;

        [Display(Name = "PLZ")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; } = string.Empty;

        [Display(Name = "Ort")]
        public string City { get; set; } = string.Empty;

        [Display(Name = "Adresse")]
        public string Summary => Street + ", " + Zip + " " + City;
    }
}
