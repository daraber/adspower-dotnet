using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Browser;

public interface IBrowserApi
{
    /// <summary>
    /// Opens a browser using the specified profile ID.
    /// After a successful launch, you can obtain the browser's debug interface for executing Selenium and Puppeteer automation.
    /// This feature requires AdsPower version 2.5.6.2 or higher.
    /// </summary>
    /// <param name="request">The request object containing the profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<StartBrowserResponse> StartAsync(
        StartBrowserRequest request,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Closes a browser using the specified profile ID.
    /// </summary>
    /// <param name="request">The request object containing the profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<LocalApiResponse> StopAsync(BrowserRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetches the status of a browser and websocket addresses for automation using the specified profile ID.
    /// </summary>
    /// <param name="request">The request object containing the profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<BrowserStatusResponse> GetStatusAsync(
        BrowserRequest request,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Queries browser information.
    /// </summary>
    /// <param name="request">The request object containing the profile ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<BrowserStatusListResponse> ListAsync(
        BrowserRequest? request,
        CancellationToken cancellationToken = default
    );
}