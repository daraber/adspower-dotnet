using AdsPower.LocalApi.Profile.Requests;
using AdsPower.LocalApi.Profile.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile;

public interface IProfileApi
{
    Task<CreateProfileResponse> CreateAsync(CreateProfileRequest request, CancellationToken cancellationToken = default);
    Task<LocalApiResponse> UpdateAsync(UpdateProfileRequest request, CancellationToken cancellationToken = default);
    Task<ListProfilesResponse> ListAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(DeleteProfileRequest request, CancellationToken cancellationToken = default);
    Task RegroupAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
    Task DeleteCacheAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
}