using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;

namespace AdsPower.LocalApi.Browser;

public class BrowserApi(LocalApiClient apiClient) : IBrowserApi
{
    public async Task<StartBrowserResponse> StartAsync(
        StartBrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        // TODO: Pass request data as query string
        const string endpoint = "api/v1/browser/start";
        return await apiClient.GetAsync<StartBrowserResponse>(endpoint, cancellationToken);
    }

    public Task StopAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        const string endpoint = "/api/v1/browser/stop";
        throw new NotImplementedException();
    }

    public Task GetStatusAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        const string endpoint = "/api/v1/browser/active";
        throw new NotImplementedException();
    }

    public Task DeleteCacheAsync(CancellationToken cancellationToken = default)
    {
        const string endpoint = "/api/v1/user/delete-cache";
        throw new NotImplementedException();
    }
}