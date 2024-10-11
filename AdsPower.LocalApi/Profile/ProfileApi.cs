using AdsPower.LocalApi.Profile.Requests;

namespace AdsPower.LocalApi.Profile;

public class ProfileApi : IProfileApi
{
    public Task CreateAsync(CreateProfileRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/user/create";
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateProfileRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/user/update";
        throw new NotImplementedException();
    }

    public Task ListAsync(MoveProfileRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/user/list";
        throw new NotImplementedException();
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