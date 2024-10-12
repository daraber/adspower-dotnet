using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group;

/// <summary>
/// Defines the API for group operations.
/// </summary>
public interface IGroupApi
{
    public Task<CreateGroupResponse> CreateAsync(GroupRequest request, CancellationToken cancellationToken = default);
    public Task<LocalApiResponse> UpdateAsync(UpdateGroupRequest request, CancellationToken cancellationToken = default);
    public Task<GroupListResponse> ListAsync(ListGroupsRequest request, CancellationToken cancellationToken = default);
}