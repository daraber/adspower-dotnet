using AdsPower.LocalApi.Profile.Requests;

namespace AdsPower.LocalApi.Profile;

public interface IProfileApi
{
    Task CreateAsync(CreateProfileRequest request, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateProfileRequest request, CancellationToken cancellationToken = default);
    Task ListAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(DeleteProfileRequest request, CancellationToken cancellationToken = default);
    Task RegroupAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
    Task DeleteCacheAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
}