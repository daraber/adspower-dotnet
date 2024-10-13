using System.Net.Http.Json;
using System.Web;
using AdsPower.LocalApi.Application;
using AdsPower.LocalApi.Browser;
using AdsPower.LocalApi.Group;
using AdsPower.LocalApi.Profile;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi;

public class LocalApiClient(string url, HttpMessageHandler? handler = null) : ILocalApiClient, IDisposable
{
    private readonly HttpClient _httpClient = new(handler ?? new HttpClientHandler());

    public BrowserApi Browser => new(this);
    public GroupApi Group => new(this);
    public IApplicationApi Application => new ApplicationApi(this);
    public IProfileApi Profile => new ProfileApi(this);

    public async Task<LocalApiResponse> GetConnectionStatusAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<LocalApiResponse>("status", cancellationToken);
    }

    public async Task<T> PostAsync<T>(string path, object request, CancellationToken cancellationToken = default)
        where T : LocalApiResponse
    {
        using var response = await _httpClient.PostAsJsonAsync($"{url}{path}", request, cancellationToken);

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
    
    public async Task<T> GetAsync<T>(
        string path,
        IQueryParameterizeable request,
        CancellationToken cancellationToken = default
    ) where T : LocalApiResponse
    {
        var query = "?";

        foreach (var (key, value) in request.GetQueryParameters())
        {
            query += $"{key}={HttpUtility.UrlEncode(value)}&";
        }
        
        return await GetAsync<T>($"{path}{query}", cancellationToken);
    }

    private async Task<T> GetAsync<T>(string path, CancellationToken cancellationToken = default)
        where T : LocalApiResponse
    {
        var uri = new Uri($"{url}{path}");
        using var response = await _httpClient.GetAsync(uri, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var message =
                $"Bad HTTP response from {uri} for type {typeof(T).Name}: {response.StatusCode} {response.ReasonPhrase}";

            throw new HttpRequestException(message);
        }

        var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        if (result is null)
        {
            var message = $"Deserialized HTTP response from {uri} of type {typeof(T).Name} is null";
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