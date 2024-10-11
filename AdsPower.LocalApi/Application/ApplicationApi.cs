using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;

namespace AdsPower.LocalApi.Application;

public class ApplicationApi(LocalApiClient apiClient) : IApplicationApi
{
    public Task<ListApplicationResponse> ListAsync(
        ListApplicationsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/application/list";
        return apiClient.GetAsync<ListApplicationResponse>(path, request, cancellationToken);
    }
}