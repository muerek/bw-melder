using System;
using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model
{
    public class TeamCoachAccessKey
    {
        public Guid Id { get; set; } = Guid.Empty;

        [Display(Name = "Schlüssel")]
        public string Key { get; set; } = string.Empty;

        public Guid? TeamCoachId { get; set; } = null;

    }
}
