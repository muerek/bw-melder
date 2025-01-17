using BwMelder.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Services;

public interface ICrewService
{
    Task<Guid> CreateCrewAsync(CreateCrewRequest request);
}
