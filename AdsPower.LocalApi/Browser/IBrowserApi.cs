using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Browser;

public interface IBrowserApi
{
    public Task<StartBrowserResponse> StartAsync(StartBrowserRequest request, CancellationToken cancellationToken = default);
    public Task<LocalApiResponse> StopAsync(BrowserRequest request, CancellationToken cancellationToken = default);
    public Task<BrowserStatusResponse> GetStatusAsync(BrowserRequest request, CancellationToken cancellationToken = default);
    public Task<BrowserStatusListResponse> GetStatusListAsync(CancellationToken cancellationToken = default);
}