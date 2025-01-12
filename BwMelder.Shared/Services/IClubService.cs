using BwMelder.Shared.Dto;

namespace BwMelder.Shared.Services;

public interface IClubService
{
    Task<Guid> CreateClubAsync(CreateClubRequest request);
}