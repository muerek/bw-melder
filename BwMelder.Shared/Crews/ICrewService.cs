using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Shared.Crews;

/// <summary>
/// Represents a service to manage crews.
/// </summary>
public interface ICrewService
{
    /// <summary>
    /// Creates a new crew.
    /// </summary>
    /// <param name="request">Request object specifying details like race and club of the crew.</param>
    /// <returns>Unique ID of the new crew.</returns>
    Task<Guid> CreateCrewAsync(CreateCrewRequest request);
}
