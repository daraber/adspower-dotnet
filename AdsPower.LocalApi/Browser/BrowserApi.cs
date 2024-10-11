using AdsPower.LocalApi.Browser.Models;
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
        const string path = "api/v1/browser/start";
        return await apiClient.GetAsync<StartBrowserResponse>(path, request, cancellationToken);
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

    public Task<BrowserStatusList> GetStatusListAsync(CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/browser/local-active";
        return apiClient.GetAsync<BrowserStatusList>(path, cancellationToken);
    }
}