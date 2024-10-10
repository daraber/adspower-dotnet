using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi;

public interface IBrowserApi
{
    public Task StartAsync(StartBrowserRequest request, CancellationToken cancellationToken = default);
    public Task StopAsync(BrowserRequest request, CancellationToken cancellationToken = default);
    public Task GetStatusAsync(BrowserRequest request, CancellationToken cancellationToken = default);
    public Task DeleteCacheAsync(CancellationToken cancellationToken = default);
}