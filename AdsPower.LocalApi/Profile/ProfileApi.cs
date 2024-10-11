using AdsPower.LocalApi.Profile.Requests;
using AdsPower.LocalApi.Profile.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Profile;

public class ProfileApi(LocalApiClient client) : IProfileApi
{
    public async Task<CreateProfileResponse> CreateAsync(CreateProfileRequest request,
        CancellationToken cancellationToken = default)
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

    public async Task<ListProfilesResponse> ListAsync(
        MoveProfileRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/user/list";
        return await client.PostAsync<ListProfilesResponse>(path, request, cancellationToken);
    }

    public Task DeleteAsync(DeleteProfileRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/user/delete";
        throw new NotImplementedException();
    }

    public Task RegroupAsync(MoveProfileRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/user/regroup";
        throw new NotImplementedException();
    }

    public Task DeleteCacheAsync(MoveProfileRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/user/delete-cache";
        throw new NotImplementedException();
    }
}