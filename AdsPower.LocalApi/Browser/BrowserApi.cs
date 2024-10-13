using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Browser;

/// <summary>
/// Provides methods to interact with browser operations.
/// </summary>
public class BrowserApi(ILocalApiClient apiClient) : IBrowserApi
{
    #region StartAsync

    /// <summary>
    /// Opens a browser using the specified profile ID.
    /// After a successful launch, you can obtain the browser's debug interface for executing Selenium and Puppeteer automation.
    /// This feature requires AdsPower version 2.5.6.2 or higher.
    /// </summary>
    /// <param name="userId">The unique profile ID. </param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<StartBrowserResponse> StartAsync(string userId, CancellationToken cancellationToken = default)
    {
        var request = new StartBrowserRequest { UserId = userId };
        return await StartAsync(request, cancellationToken);
    }

    /// <summary>
    /// Opens a browser using the specified profile ID.
    /// After a successful launch, you can obtain the browser's debug interface for executing Selenium and Puppeteer automation.
    /// This feature requires AdsPower version 2.5.6.2 or higher.
    /// </summary>
    /// <param name="request">The request object containing the profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
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

    /// <summary>
    /// Closes a browser using the specified profile ID.
    /// </summary>
    /// <param name="userId">The unique profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<LocalApiResponse> StopAsync(string userId, CancellationToken cancellationToken = default)
    {
        var request = new BrowserRequest { UserId = userId };
        return await StopAsync(request, cancellationToken);
    }

    /// <summary>
    /// Closes a browser using the specified profile ID.
    /// </summary>
    /// <param name="request">The request object containing the profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<LocalApiResponse> StopAsync(BrowserRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/browser/stop";
        return await apiClient.GetAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    #endregion

    #region GetStatusAsync

    /// <summary>
    /// Fetches the status of a browser and websocket addresses for automation using the specified profile ID.
    /// </summary>
    /// <param name="userId">The unique profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<BrowserStatusResponse> GetStatusAsync(string userId, CancellationToken cancellationToken = default)
    {
        var request = new BrowserRequest { UserId = userId };
        return GetStatusAsync(request, cancellationToken);
    }

    /// <summary>
    /// Fetches the status of a browser and websocket addresses for automation using the specified profile ID.
    /// </summary>
    /// <param name="request">The request object containing the profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
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

    // TODO: userId / profile ID is not required when fetching browser status(es)
    
    /// <summary>
    /// Queries browser information.
    /// </summary>
    /// <param name="userId">The unique profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<BrowserStatusListResponse> GetStatusListAsync(string userId, CancellationToken cancellationToken = default)
    {
        var request = new BrowserRequest { UserId = userId };
        return GetStatusListAsync(request, cancellationToken);
    }

    /// <summary>
    /// Queries browser information.
    /// </summary>
    /// <param name="request">The request object containing the profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
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