using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi;

public interface ILocalApiClient
{
    Task<LocalApiResponse> GetConnectionStatusAsync(CancellationToken cancellationToken = default);
}