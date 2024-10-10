using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi;

public interface ILocalApiClient
{
    Task<LocalApiResponse> GetConnectionStatus(CancellationToken cancellationToken = default);
}