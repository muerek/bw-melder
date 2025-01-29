using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Authentication;

/// <summary>
/// DTO representing the credentials a user provided to login.
/// </summary>
public class UserLoginRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}
