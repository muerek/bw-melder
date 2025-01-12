using BwMelder.Data.Model;
using BwMelder.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Services;

public interface IAccessKeyService
{
    public static bool ValidateAccessKey(AccessKey key) =>
        key.Active && key.NotBefore <= DateTime.Now && DateTime.Now <= key.NotAfter;

    public Task<IList<ClubKey>> GetClubKeysAsync();

    public Task RenewAccessAsync(Guid clubId);

    public Task LockAccessAsync(Guid clubId);
}
