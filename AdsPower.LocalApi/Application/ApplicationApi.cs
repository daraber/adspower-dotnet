using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi.Application;

public class ApplicationApi : IApplicationApi
{
    public Task ListAsync(ListApplicationsRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}