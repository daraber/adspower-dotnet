using AdsPower.LocalApi.Group.Requests;
using AdsPower.LocalApi.Group.Responses;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi.Group;

public interface IGroupApi
{
    public Task<CreateGroupResponse> CreateAsync(GroupRequest request, CancellationToken cancellationToken = default);
    public Task<LocalApiResponse> UpdateAsync(UpdateGroupRequest request, CancellationToken cancellationToken = default);
    public Task ListAsync(QueryGroupRequest request, CancellationToken cancellationToken = default);
}