using BwMelder.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Services;

public interface IAccessKeyService
{
    /// <summary>
    /// Tries to authenticate the given secret.
    /// </summary>
    /// <param name="secret"></param>
    /// <returns>Authentication result and, if successful, additional information on the user.</returns>
    Task<AuthenticationResponse> AuthenticateAsync(string secret);

    /// <summary>
    /// Gets a list of <see cref="ClubKey"/> DTOs listing all clubs with their active key.
    /// Clubs without an active key will have <see cref="ClubKey.SecretUrl"/> set to null.
    /// </summary>
    /// <returns></returns>
    Task<IList<ClubKey>> GetClubKeysAsync();

    /// <summary>
    /// Renew access to the application for a club.
    /// Generates a new and active access key.
    /// All older access keys will be invalidated.
    /// </summary>
    /// <param name="clubId">Renew access for the club with this ID.</param>
    /// <returns>The secret of the new access key.</returns>
    Task<string> RenewAccessAsync(Guid clubId);

    /// <summary>
    /// Lock access for a club by invalidating all access keys.
    /// </summary>
    /// <param name="clubId">Lock access for the club with this ID.</param>
    Task LockAccessAsync(Guid clubId);
}
