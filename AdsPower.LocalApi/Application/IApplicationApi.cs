using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;

namespace AdsPower.LocalApi.Application;

/// <summary>
/// Defines the API for application operations.
/// </summary>
public interface IApplicationApi
{
    Task<ApplicationListResponse> ListAsync(ListApplicationsRequest request, CancellationToken cancellationToken = default);
}