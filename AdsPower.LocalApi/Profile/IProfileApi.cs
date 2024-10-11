using AdsPower.LocalApi.Profile.Requests;

namespace AdsPower.LocalApi.Profile;

public interface IProfileApi
{
    Task CreateProfileAsync(CreateProfileRequest request, CancellationToken cancellationToken = default);
    Task UpdateProfileAsync(UpdateProfileRequest request, CancellationToken cancellationToken = default);
    Task DeleteProfileAsync(DeleteProfileRequest request, CancellationToken cancellationToken = default);
    Task MoveProfileAsync(MoveProfileRequest request, CancellationToken cancellationToken = default);
    
}