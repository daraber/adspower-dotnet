using AdsPower.LocalApi.Application.Requests;
using AdsPower.LocalApi.Application.Responses;

namespace AdsPower.LocalApi.Application;

public interface IApplicationApi
{
    /// <summary>
    /// Queries the list of application categories.
    /// </summary>
    /// <param name="request">The request object containing the query parameters.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task<ApplicationListResponse> ListAsync(
        ListApplicationsRequest request,
        CancellationToken cancellationToken = default
    );
}