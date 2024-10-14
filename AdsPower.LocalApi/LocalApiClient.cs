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
    public ApplicationApi Application => new(this);
    public ProfileApi Profile => new(this);

    public async Task<LocalApiResponse> GetConnectionStatusAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<LocalApiResponse>("/status", null, cancellationToken);
    }

    public async Task<T> PostAsync<T>(string path, object request, CancellationToken cancellationToken = default)
        where T : LocalApiResponse
    {
        var uriBuilder = new UriBuilder(url)
        {
            Path = path
        };
        
        using var response = await _httpClient.PostAsJsonAsync(uriBuilder.Uri, request, cancellationToken);

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
        IQueryParameterizeable? request,
        CancellationToken cancellationToken = default
    ) where T : LocalApiResponse
    {
        var uriBuilder = new UriBuilder(url)
        {
            Path = path,
        };

        if (request is not null)
        {
            var query = string.Empty;

            foreach (var (key, value) in request.GetQueryParameters())
            {
                query += $"{key}={HttpUtility.UrlEncode(value)}&";
            }

            uriBuilder.Query = query;
        }

        using var response = await _httpClient.GetAsync(uriBuilder.Uri, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var message =
                $"Bad HTTP response from {uriBuilder} for type {typeof(T).Name}: {response.StatusCode} {response.ReasonPhrase}";

            throw new HttpRequestException(message);
        }

        var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        if (result is null)
        {
            var message = $"Deserialized HTTP response from {uriBuilder} of type {typeof(T).Name} is null";
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