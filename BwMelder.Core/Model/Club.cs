using System.ComponentModel.DataAnnotations;

namespace BwMelder.Core.Model;

/// <summary>
/// Represents a club that registers crews and team coaches.
/// </summary>
class Club
{
    public Guid Id { get; set; } = Guid.Empty;

    /// <summary>
    /// Name of the club.
    /// </summary>
    [Display(Name = "Vereinsname")]
    public string Name { get; set; } = string.Empty;

    public ClubCoach? ClubCoach { get; set; } = null;

    public IList<TeamCoach> TeamCoaches { get; set; } = [];

    public IList<Crew> Crews { get; set; } = [];

    public IList<AccessKey> AccessKeys { get; set; } = [];
}
