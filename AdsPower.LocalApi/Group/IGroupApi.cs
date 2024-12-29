using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group;

public interface IGroupApi
{
    /// <summary>
    /// Creates a new profile group. Default group ID is 0.
    /// </summary>
    /// <param name="request">The request object containing the group details.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<CreateGroupResponse> CreateAsync(GroupRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Edits existing group name and/or remarks.
    /// This feature requires AdsPower version 2.5.6.2 or higher.
    /// </summary>
    /// <param name="request">The request object containing the group details to edit.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<LocalApiResponse> UpdateAsync(UpdateGroupRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Queries group information.
    /// Default group ID is 0.
    /// </summary>
    /// <param name="request">The request object containing the query parameters.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<GroupListResponse> ListAsync(ListGroupsRequest request, CancellationToken cancellationToken = default);
}