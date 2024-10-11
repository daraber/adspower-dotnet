using System.Net.Http.Json;
using System.Web;
using AdsPower.LocalApi.Application;
using AdsPower.LocalApi.Browser;
using AdsPower.LocalApi.Group;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Profile;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi;

public class LocalApiClient(string url, HttpMessageHandler? handler) : ILocalApiClient, IDisposable
{
    private readonly HttpClient _httpClient = new(handler ?? new HttpClientHandler());

    public IBrowserApi Browser => new BrowserApi(this);
    public IGroupApi Group => new GroupApi(this);
    public IApplicationApi Application => new ApplicationApi(this);
    public IProfileApi Profile => new ProfileApi(this);

    public async Task<LocalApiResponse> GetConnectionStatusAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<LocalApiResponse>("status", cancellationToken);
    }

    internal async Task<T> GetAsync<T>(
        string path,
        IQueryParameterizeable request,
        CancellationToken cancellationToken = default
    ) where T : LocalApiResponse
    {
        var queryString = request.GetQueryParameters()
            .Aggregate("", (current, pair) => $"{current}&{pair.Key}={HttpUtility.UrlEncode(pair.Value)}");

        return await GetAsync<T>($"{path}?{queryString}", cancellationToken);
    }

    internal async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
        where T : LocalApiResponse
    {
        using var response = await _httpClient.GetAsync($"{url}/{path}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var message =
                $"Bad HTTP response from {path} for type {typeof(T).Name}: {response.StatusCode} {response.ReasonPhrase}";

            throw new HttpRequestException(message);
        }

        var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        if (result is null)
        {
            var message = $"Deserialized HTTP response from {path} of type {typeof(T).Name} is null";
            throw new HttpRequestException(message);
        }

        return result;
    }

    internal async Task<T> PostAsync<T>(string path, object request, CancellationToken cancellationToken = default)
        where T : LocalApiResponse
    {
        using var response = await _httpClient.PostAsJsonAsync($"{url}/{path}", request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var message =
                $"Bad HTTP response from {path} for type {typeof(T).Name}: {response.StatusCode} {response.ReasonPhrase}";

            throw new HttpRequestException(message);
        }

        var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        if (result is null)
        {
            var message = $"Deserialized HTTP response from {path} of type {typeof(T).Name} is null";
            throw new HttpRequestException(message);
        }

        return result;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }
}