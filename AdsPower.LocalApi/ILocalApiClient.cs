using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi;

public interface ILocalApiClient
{
    Task<LocalApiResponse> GetConnectionStatusAsync(CancellationToken cancellationToken = default);

    Task<T> GetAsync<T>(string path, IQueryParameterizeable? request, CancellationToken cancellationToken = default)
        where T : LocalApiResponse;

    Task<T> PostAsync<T>(string path, object request, CancellationToken cancellationToken = default)
        where T : LocalApiResponse;
}