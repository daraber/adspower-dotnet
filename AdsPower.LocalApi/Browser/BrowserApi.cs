using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Browser;

public class BrowserApi(LocalApiClient apiClient) : IBrowserApi
{
    public async Task<StartBrowserResponse> StartAsync(StartBrowserRequest request, CancellationToken cancellationToken = default)
    {
        return await apiClient.GetAsync<StartBrowserResponse>("api/v1/browser/start", request, cancellationToken);
    }

    public async Task<LocalApiResponse> StopAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/browser/stop";
        return await apiClient.GetAsync<LocalApiResponse>(path, cancellationToken);
    }

    public Task<BrowserStatusResponse> GetStatusAsync(
        BrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/browser/active";
        return apiClient.GetAsync<BrowserStatusResponse>(path, request, cancellationToken);
    }

    public Task<BrowserStatusListResponse> GetStatusListAsync(CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/browser/local-active";
        return apiClient.GetAsync<BrowserStatusListResponse>(path, cancellationToken);
    }
}