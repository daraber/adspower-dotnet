using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group;

public class GroupApi(ILocalApiClient apiClient) : IGroupApi
{
    #region CreateAsync

    public Task<CreateGroupResponse> CreateAsync(string groupName, CancellationToken cancellationToken = default)
    {
        var request = new GroupRequest { GroupName = groupName };
        return apiClient.PostAsync<CreateGroupResponse>("api/v1/group/create", request, cancellationToken);
    }

    public Task<CreateGroupResponse> CreateAsync(GroupRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/create";
        return apiClient.PostAsync<CreateGroupResponse>(path, request, cancellationToken);
    }

    #endregion

    #region UpdateAsync

    public Task<LocalApiResponse> UpdateAsync(
        string groupId,
        string groupName,
        CancellationToken cancellationToken = default
    )
    {
        var request = new UpdateGroupRequest { GroupId = groupId, GroupName = groupName };
        return apiClient.PostAsync<LocalApiResponse>("api/v1/group/update", request, cancellationToken);
    }

    public Task<LocalApiResponse> UpdateAsync(UpdateGroupRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/update";
        return apiClient.PostAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    #endregion

    #region ListAsync
    
    public Task<GroupListResponse> ListAsync(ListGroupsRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/list";
        return apiClient.GetAsync<GroupListResponse>(path, request, cancellationToken);
    }

    #endregion
}