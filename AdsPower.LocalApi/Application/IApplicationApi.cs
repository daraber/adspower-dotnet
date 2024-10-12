using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;

namespace AdsPower.LocalApi.Application;

public interface IApplicationApi
{
    Task<ApplicationListResponse> ListAsync(ListApplicationsRequest request, CancellationToken cancellationToken = default);
}