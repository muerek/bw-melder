using System;

namespace BwMelder.Model
{
    public class TeamCoachKey
    {
        public int Id { get; set; } = 0;

        // Guid is used as secret key because it is hard to guess and collision-free.
        public Guid Secret { get; private set; } = Guid.NewGuid();

        public virtual TeamCoach? TeamCoach { get; set; } = null;

        public string? Comment { get; set; } = string.Empty;
    }
}
