using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.ClubCoaches;

/// <summary>
/// A request to create a new club coach.
/// </summary>
public class CreateClubCoachRequest
{
    [Required, NotDefault]
    public string FirstName { get; set; } = string.Empty;

    [Required, NotDefault]
    public string LastName { get; set; } = string.Empty;

    [ValidateComplexType]
    public ContactRequest Contact { get; set; } = new();

    /// <summary>
    /// Unique ID of the club this coach belongs to.
    /// </summary>
    [Required, NotDefault]
    public Guid ClubId { get; set; } = default;
}
