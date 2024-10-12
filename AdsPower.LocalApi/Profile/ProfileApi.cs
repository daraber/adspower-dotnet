using AdsPower.LocalApi.Profile.Requests;
using AdsPower.LocalApi.Profile.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile;

public class ProfileApi(ILocalApiClient client) : IProfileApi
{
    public async Task<CreateProfileResponse> CreateAsync(
        CreateProfileRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/user/create";
        return await client.PostAsync<CreateProfileResponse>(path, request, cancellationToken);
    }

    public async Task<LocalApiResponse> UpdateAsync(
        UpdateProfileRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/user/update";
        return await client.PostAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    public async Task<ProfilesListResponse> ListAsync(
        MoveProfileRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/user/list";
        return await client.PostAsync<ProfilesListResponse>(path, request, cancellationToken);
    }

    public async Task<LocalApiResponse> DeleteAsync(
        DeleteProfileRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/user/delete";
        return await client.PostAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    public async Task<LocalApiResponse> RegroupAsync(
        MoveProfileRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/user/regroup";
        return await client.PostAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    public async Task<LocalApiResponse> DeleteCacheAsync(
        MoveProfileRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/user/delete-cache";
        return await client.PostAsync<LocalApiResponse>(path, request, cancellationToken);
    }
}