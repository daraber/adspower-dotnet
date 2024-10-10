using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi;

public interface IBrowserApi
{
    public Task StartAsync(StartBrowserRequest request, CancellationToken cancellationToken = default);
}