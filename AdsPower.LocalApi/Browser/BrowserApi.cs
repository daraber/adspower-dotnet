using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi.Browser;

public class BrowserApi(LocalApiClient apiClient) : IBrowserApi
{
    public async Task<StartBrowserResponse> StartAsync(
        StartBrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string endpoint = "api/v1/browser/start";
        return await apiClient.GetAsync<StartBrowserResponse>(endpoint, request, cancellationToken);
    }

    public async Task<LocalApiResponse> StopAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        const string endpoint = "/api/v1/browser/stop";
        return await apiClient.GetAsync<LocalApiResponse>(endpoint, cancellationToken);
    }

    public Task<BrowserStatusResponse> GetStatusAsync(
        BrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string endpoint = "/api/v1/browser/active";
        return apiClient.GetAsync<BrowserStatusResponse>(endpoint, request, cancellationToken);
    }

    public Task DeleteCacheAsync(CancellationToken cancellationToken = default)
    {
        const string endpoint = "/api/v1/user/delete-cache";
        throw new NotImplementedException();
    }
}