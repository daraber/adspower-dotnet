using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi;

public class BrowserApi(LocalApiClient apiClient) : IBrowserApi
{
    public Task StartAsync(
        StartBrowserRequest request,
        CancellationToken cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }
}