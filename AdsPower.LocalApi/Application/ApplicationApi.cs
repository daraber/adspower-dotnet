using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;

namespace AdsPower.LocalApi.Application;

public class ApplicationApi(ILocalApiClient apiClient) : IApplicationApi
{
    public Task<ApplicationListResponse> ListAsync(
        ListApplicationsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/application/list";
        return apiClient.GetAsync<ApplicationListResponse>(path, request, cancellationToken);
    }
}