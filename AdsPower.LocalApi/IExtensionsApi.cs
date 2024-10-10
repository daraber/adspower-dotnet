using AdsPower.LocalApi.Requests;

namespace AdsPower.LocalApi;

public interface IExtensionsApi
{
    Task ListAsync(ListExtensionsRequest request, CancellationToken cancellationToken = default);
}