using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Dto;

/// <summary>
/// DTO representing a new or updated club coach.
/// </summary>
public class ClubCoachRequest
{
    public int Id { get; set; } = 0;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [ValidateComplexType]
    public ContactRequest Contact { get; set; } = new();

    public Guid ClubId { get; set; } = Guid.Empty;
}
