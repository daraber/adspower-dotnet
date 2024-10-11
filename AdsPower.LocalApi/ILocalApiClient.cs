using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi;

public interface ILocalApiClient
{
    Task<LocalApiResponse> GetConnectionStatusAsync(CancellationToken cancellationToken = default);
}