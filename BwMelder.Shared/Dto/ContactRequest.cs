using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Dto;

/// <summary>
/// DTO representing common contact information.
/// </summary>
public class ContactRequest
{
    [Phone]
    [Required]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress]
    [Required]
    public string EmailAddress { get; set; } = string.Empty;
}
