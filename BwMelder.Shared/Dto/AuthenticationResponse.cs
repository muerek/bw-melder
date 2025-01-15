using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Dto;

/// <summary>
/// DTO representing the response to a authentication request.
/// For successful authentications, it returns additional user data.
/// </summary>
public class AuthenticationResponse
{
    public required bool IsSuccess { get; set; }

    public bool OnboardingRequired { get; set; } = false;

    public string? Role { get; set; }

    public Guid? ClubId { get; set; }

    public string? ClubName { get; set; }
}
