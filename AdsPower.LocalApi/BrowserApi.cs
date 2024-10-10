using AdsPower.LocalApi.Requests;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi;

public class BrowserApi(LocalApiClient apiClient) : IBrowserApi
{
    public async Task<StartBrowserResponse> StartAsync(
        StartBrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string endpoint = "api/v1/browser/start";
        return await apiClient.GetAsync<StartBrowserResponse>(endpoint, cancellationToken);
    }

    public Task StopAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task GetStatusAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCacheAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}