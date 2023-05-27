using System;
using System.ComponentModel.DataAnnotations;

namespace BwMelder.Model
{
    public class TeamCoachKey
    {
        public int Id { get; set; } = 0;

        // Guid is used as secret key because it is hard to guess and collision-free.
        [Display(Name = "Schlüssel")]
        public Guid Secret { get; private set; } = Guid.NewGuid();

        public virtual TeamCoach? TeamCoach { get; set; } = null;

        [Display(Name = "Verwendung")]
        public string? Comment { get; set; } = string.Empty;
    }
}
