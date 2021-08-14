using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    /// <summary>
    /// Contact information for phone and email correspondence.
    /// </summary>
    [Owned]
    public class Contact
    {
        [Display(Name = "Telefonnummer")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "E-Mail-Adresse")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = string.Empty;
    }
}
