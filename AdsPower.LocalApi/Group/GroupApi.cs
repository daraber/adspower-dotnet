using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group;

/// <summary>
/// Provides methods to interact with group operations.
/// </summary>
public class GroupApi(ILocalApiClient apiClient) : IGroupApi
{
    #region CreateAsync

    /// <summary>
    /// Creates a new profile group. Default group ID is 0.
    /// </summary>
    /// <param name="groupName">The <b>unique</b> name of the group to be created.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<CreateGroupResponse> CreateAsync(string groupName, CancellationToken cancellationToken = default)
    {
        var request = new GroupRequest { GroupName = groupName };
        return apiClient.PostAsync<CreateGroupResponse>("api/v1/group/create", request, cancellationToken);
    }
    
    /// <inheritdoc/>
    public Task<CreateGroupResponse> CreateAsync(GroupRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/create";
        return apiClient.PostAsync<CreateGroupResponse>(path, request, cancellationToken);
    }

    #endregion

    #region UpdateAsync

    /// <summary>
    /// Edits existing group name and/or remarks.
    /// This feature requires AdsPower version 2.5.6.2 or higher.
    /// </summary>
    /// <param name="groupId">The ID of the group being edited.</param>
    /// <param name="groupName">The new <b>unique</b> name of the group.</param>
    /// <param name="remark">Optional. Modified grouping notes (requires version 2.6.7.2 or higher).</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public Task<LocalApiResponse> UpdateAsync(
        string groupId,
        string groupName,
        string? remark = null,
        CancellationToken cancellationToken = default
    )
    {
        var request = new UpdateGroupRequest { GroupId = groupId, GroupName = groupName, Remark = remark };
        return apiClient.PostAsync<LocalApiResponse>("api/v1/group/update", request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<LocalApiResponse> UpdateAsync(UpdateGroupRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/update";
        return apiClient.PostAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    #endregion

    #region ListAsync

    /// <summary>
    /// Queries group information.
    /// Default group ID is 0.
    /// </summary>
    /// <param name="groupName">Optional. The name of the group to search for. If empty, all groups will be searched.</param>
    /// <param name="page">Optional. The page number for the query. Defaults to 1 (first page).</param>
    /// <param name="pageSize">Optional. The number of items per page. Defaults to 1, with a maximum of 2000.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<GroupListResponse> ListAsync(
        string? groupName = null,
        int? page = 1,
        int? pageSize = 10,
        CancellationToken cancellationToken = default
    )
    {
        var request = new ListGroupsRequest
        {
            GroupName = groupName,
            Page = page,
            PageSize = pageSize
        };

        return await ListAsync(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<GroupListResponse> ListAsync(ListGroupsRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/list";
        return apiClient.GetAsync<GroupListResponse>(path, request, cancellationToken);
    }

    #endregion
}