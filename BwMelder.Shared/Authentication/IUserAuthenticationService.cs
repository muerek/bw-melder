using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Authentication;

/// <summary>
/// Describes a service to handle authentication for users with username and password.
/// </summary>
public interface IUserAuthenticationService
{
    Task<AuthenticationResponse> AuthenticateAsync(UserLoginRequest loginRequest);
}
