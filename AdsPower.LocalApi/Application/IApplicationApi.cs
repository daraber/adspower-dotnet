using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi.Application;

public interface IApplicationApi
{
    Task ListAsync(ListApplicationsRequest request, CancellationToken cancellationToken = default);
}