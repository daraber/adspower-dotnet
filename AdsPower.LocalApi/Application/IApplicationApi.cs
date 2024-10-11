using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;
using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi.Application;

public interface IApplicationApi
{
    Task<ListApplicationResponse> ListAsync(ListApplicationsRequest request, CancellationToken cancellationToken = default);
}