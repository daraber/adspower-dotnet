using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi;

public interface IGroupApi
{
    public Task CreateAsync(GroupRequest request, CancellationToken cancellationToken = default);
    public Task UpdateAsync(UpdateGroupRequest request, CancellationToken cancellationToken = default);
    public Task QueryAsync(QueryGroupRequest request, CancellationToken cancellationToken = default);
    
}