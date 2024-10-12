using AdsPower.LocalApi.Profile.Requests;
using AdsPower.LocalApi.Profile.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile;

/// <summary>
/// Defines the API for profile operations.
/// </summary>
public interface IProfileApi
{
    Task<CreateProfileResponse> CreateAsync(CreateProfileRequest request, CancellationToken cancellationToken = default);
    Task<LocalApiResponse> UpdateAsync(UpdateProfileRequest request, CancellationToken cancellationToken = default);
    Task<ProfilesListResponse> ListAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
    Task<LocalApiResponse> DeleteAsync(DeleteProfileRequest request, CancellationToken cancellationToken = default);
    Task<LocalApiResponse> RegroupAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
    Task<LocalApiResponse> DeleteCacheAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
}