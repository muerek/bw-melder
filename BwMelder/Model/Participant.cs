using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    /// <summary>
    /// Common data on all participants.
    /// </summary>
    public abstract class Participant
    {
        public Guid Id { get; set; } = Guid.Empty;

        [Display(Name = "Vorname")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Nachname")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Name")]
        public string FullName => FirstName + " " + LastName;

        [Display(Name = "Geburtstag")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-14);

        [Display(Name = "Adresse")]
        public Address Address { get; set; } = new();

        [Display(Name = "Verpflegung")]
        public Diet Diet { get; set; } = new();

        [Display(Name = "T-Shirt-Größe")]
        public ShirtSize ShirtSize { get; set; } = ShirtSize.M;

        [Display(Name = "Medizinische Hinweise und weitere Bemerkungen")]
        [DataType(DataType.MultilineText)]
        public string? Comments { get; set; } = string.Empty;
    }
}
