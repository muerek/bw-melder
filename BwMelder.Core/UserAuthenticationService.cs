using BwMelder.Shared.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Core;

public class UserAuthenticationService(IConfiguration config) : IUserAuthenticationService
{
    public async Task<AuthenticationResponse> AuthenticateAsync(UserLoginRequest loginRequest)
    {
        // Credentials are currently stored in the configuration in plaintext.
        // TODO: Do something else here.
        var validUser = config.GetValue<string>("AppAdmin:Username");
        var validPassword = config.GetValue<string>("AppAdmin:Password");
        if (validUser == null || validPassword == null)
        {
            throw new ApplicationException("No admin user configured.");
        }
        if (validUser == loginRequest.Username && validPassword == loginRequest.Password)
        {
            return new AuthenticationResponse
            {
                IsSuccess = true,
                Role = "Administrator",
            };
        }

        return new AuthenticationResponse { IsSuccess = false };
    }
}
