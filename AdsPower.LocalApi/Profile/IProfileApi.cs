using AdsPower.LocalApi.Profile.Requests;
using AdsPower.LocalApi.Profile.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile;

public interface IProfileApi
{
    Task<CreateProfileResponse> CreateAsync(
        CreateProfileRequest request,
        CancellationToken cancellationToken = default
    );

    Task<LocalApiResponse> UpdateAsync(UpdateProfileRequest request, CancellationToken cancellationToken = default);
    Task<ProfilesListResponse> ListAsync(ListProfilesRequest request, CancellationToken cancellationToken = default);
    Task<LocalApiResponse> DeleteAsync(DeleteProfileRequest request, CancellationToken cancellationToken = default);
    Task<LocalApiResponse> RegroupAsync(RegroupProfilesRequest request, CancellationToken cancellationToken = default);
    Task<LocalApiResponse> DeleteCacheAsync(CancellationToken cancellationToken = default);
}