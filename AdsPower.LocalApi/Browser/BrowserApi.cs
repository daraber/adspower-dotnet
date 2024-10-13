using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Browser;

public class BrowserApi(ILocalApiClient apiClient) : IBrowserApi
{
    public async Task<StartBrowserResponse> StartAsync(
        StartBrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/browser/start";
        return await apiClient.GetAsync<StartBrowserResponse>(path, request, cancellationToken);
    }

    public async Task<LocalApiResponse> StopAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/browser/stop";
        return await apiClient.GetAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    public Task<BrowserStatusResponse> GetStatusAsync(
        BrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/browser/active";
        return apiClient.GetAsync<BrowserStatusResponse>(path, request, cancellationToken);
    }

    public Task<BrowserStatusListResponse> GetStatusListAsync(
        BrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/browser/local-active";
        return apiClient.GetAsync<BrowserStatusListResponse>(path, request, cancellationToken);
    }
}