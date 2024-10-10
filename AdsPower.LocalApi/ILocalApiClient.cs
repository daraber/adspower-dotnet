using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi;

public interface ILocalApiClient
{
    Task<StatusResponse> GetStatusAsync(CancellationToken cancellationToken = default);
}