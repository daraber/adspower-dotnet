using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;

namespace AdsPower.LocalApi.Application;

/// <summary>
/// Provides methods to interact with application operations.
/// </summary>
public class ApplicationApi(ILocalApiClient apiClient) : IApplicationApi
{
    /// <summary>
    /// Queries the list of application categories.
    /// </summary>
    /// <param name="page">Optional. The page number for the query. Defaults to 1 (first page).</param>
    /// <param name="pageSize">Optional. The number of items per page. Defaults to 1.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<ApplicationListResponse> ListAsync(
        int? page = 1,
        int? pageSize = 1,
        CancellationToken cancellationToken = default
    )
    {
        var request = new ListApplicationsRequest
        {
            Page = page,
            PageSize = pageSize
        };

        return await ListAsync(request, cancellationToken);
    }

    /// <summary>
    /// Queries the list of application categories.
    /// </summary>
    /// <param name="request">The request object containing the query parameters.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<ApplicationListResponse> ListAsync(
        ListApplicationsRequest request,
        CancellationToken cancellationToken = default
    )
    {
        const string path = "/api/v1/application/list";
        return apiClient.GetAsync<ApplicationListResponse>(path, request, cancellationToken);
    }
}