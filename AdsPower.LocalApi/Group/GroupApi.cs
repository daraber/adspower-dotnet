﻿using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group;

public class GroupApi(ILocalApiClient apiClient) : IGroupApi
{
    public Task<CreateGroupResponse> CreateAsync(GroupRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/create";
        return apiClient.PostAsync<CreateGroupResponse>(path, request, cancellationToken);
    }

    public Task<LocalApiResponse> UpdateAsync(UpdateGroupRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/update";
        return apiClient.PostAsync<LocalApiResponse>(path, request, cancellationToken);
    }

    public Task<GroupListResponse> ListAsync(ListGroupsRequest request, CancellationToken cancellationToken = default)
    {
        const string path = "/api/v1/group/list";
        return apiClient.GetAsync<GroupListResponse>(path, request, cancellationToken);
    }
}