using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Authentication;

/// <summary>
/// DTO representing the response to a authentication request.
/// For successful authentications, it returns additional user data.
/// </summary>
public record AuthenticationResponse
{
    /// <summary>
    /// Flag if the authentication was successful.
    /// </summary>
    public required bool IsSuccess { get; init; }

    /// <summary>
    /// Flag to indicate if the user should complete the onboarding process for their club.
    /// </summary>
    public bool OnboardingRequired { get; init; } = false;

    /// <summary>
    /// Role assigned to the user.
    /// </summary>
    public string? Role { get; init; }

    /// <summary>
    /// Unique ID of the club this user belongs to.
    /// </summary>
    public Guid? ClubId { get; init; }

    /// <summary>
    /// Name of the club this user belongs to.
    /// </summary>
    public string? ClubName { get; init; }
}
