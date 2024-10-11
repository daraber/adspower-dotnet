using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi.Group;

public interface IGroupApi
{
    public Task<CreateGroupResponse> CreateAsync(GroupRequest request, CancellationToken cancellationToken = default);
    public Task<LocalApiResponse> UpdateAsync(UpdateGroupRequest request, CancellationToken cancellationToken = default);
    public Task<ListGroupsResponse> ListAsync(ListGroupsRequest request, CancellationToken cancellationToken = default);
}