using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi;

public interface IApplicationApi
{
    Task ListAsync(ListApplicationsRequest request, CancellationToken cancellationToken = default);
}