using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi;

public interface ILocalApiClient
{
    Task<StatusResponse> GetConnectionStatus(CancellationToken cancellationToken = default);
}