using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;

namespace AdsPower.LocalApi.Browser;

public interface IBrowserApi
{
    public Task<StartBrowserResponse> StartAsync(StartBrowserRequest request, CancellationToken cancellationToken = default);
    public Task StopAsync(BrowserRequest request, CancellationToken cancellationToken = default);
    public Task GetStatusAsync(BrowserRequest request, CancellationToken cancellationToken = default);
    public Task DeleteCacheAsync(CancellationToken cancellationToken = default);
}