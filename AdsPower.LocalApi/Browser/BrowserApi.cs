using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Browser;

public class BrowserApi(ILocalApiClient apiClient) : IBrowserApi
{
    #region StartAsync

    public async Task<StartBrowserResponse> StartAsync(string userId, CancellationToken cancellationToken = default)
    {
        var request = new StartBrowserRequest { UserId = userId };
        return await StartAsync(request, cancellationToken);
    }

    public async Task<StartBrowserResponse> StartAsync(
        StartBrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/browser/start";
        return await apiClient.GetAsync<StartBrowserResponse>(path, request, cancellationToken);
    }

    #endregion

    #region StopAsync

    public async Task<LocalApiResponse> StopAsync(string userId, CancellationToken cancellationToken = default)
    {
        var request = new BrowserRequest { UserId = userId };
        return await StopAsync(request, cancellationToken);
    }

    public async Task<LocalApiResponse> StopAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/browser/stop";
        return await apiClient.GetAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    #endregion

    #region GetStatusAsync

    public Task<BrowserStatusResponse> GetStatusAsync(string userId, CancellationToken cancellationToken = default)
    {
        var request = new BrowserRequest { UserId = userId };
        return GetStatusAsync(request, cancellationToken);
    }

    public Task<BrowserStatusResponse> GetStatusAsync(
        BrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/browser/active";
        return apiClient.GetAsync<BrowserStatusResponse>(path, request, cancellationToken);
    }

    #endregion

    #region GetStatusListAsync

    public Task<BrowserStatusListResponse> GetStatusListAsync(string userId, CancellationToken cancellationToken = default)
    {
        var request = new BrowserRequest { UserId = userId };
        return GetStatusListAsync(request, cancellationToken);
    }
    
    public Task<BrowserStatusListResponse> GetStatusListAsync(
        BrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/browser/local-active";
        return apiClient.GetAsync<BrowserStatusListResponse>(path, request, cancellationToken);
    }

    #endregion
}