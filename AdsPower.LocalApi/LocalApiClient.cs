using System.Net.Http.Json;
using System.Web;
using AdsPower.LocalApi.Application;
using AdsPower.LocalApi.Browser;
using AdsPower.LocalApi.Group;
using AdsPower.LocalApi.Internal;
using AdsPower.LocalApi.Profile;
using AdsPower.LocalApi.Shared;

namespace AdsPower.LocalApi;

public class LocalApiClient(string url, HttpClient? httpClient = null, bool disposeHttpClient = true)
    : ILocalApiClient, IDisposable
{
    private readonly HttpClient _httpClient = httpClient ?? new HttpClient();

    public LocalApiClient(string url, HttpMessageHandler httpMessageHandler)
        : this(url, new HttpClient(httpMessageHandler))
    {
    }

    public BrowserApi Browser => new(this);
    public GroupApi Group => new(this);
    public ApplicationApi Application => new(this);
    public ProfileApi Profile => new(this);

    /// <inheritdoc/>
    public async Task<LocalApiResponse> GetConnectionStatusAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<LocalApiResponse>("/status", null, cancellationToken);
    }

    /// <inheritdoc/>
    async Task<T> ILocalApiClient.PostAsync<T>(string path, object request, CancellationToken cancellationToken)
    {
        return await PostAsync<T>(path, request, cancellationToken);
    }

    /// <inheritdoc/>
    async Task<T> ILocalApiClient.GetAsync<T>(
        string path,
        IQueryParameterizeable? request,
        CancellationToken cancellationToken
    )
    {
        return await GetAsync<T>(path, request, cancellationToken);
    }

    private async Task<T> PostAsync<T>(string path, object request, CancellationToken cancellationToken = default)
        where T : LocalApiResponse
    {
        var uriBuilder = new UriBuilder(url) { Path = path };

        using var response = await _httpClient.PostAsJsonAsync(uriBuilder.Uri, request, cancellationToken);
        Throw.IfNotSuccessStatusCode(response, typeof(T));

        var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        Throw.IfDeserializedResponseIsNull(result, uriBuilder.ToString());

        return result;
    }
    
    private async Task<T> GetAsync<T>(
        string path,
        IQueryParameterizeable? request,
        CancellationToken cancellationToken = default
    ) where T : LocalApiResponse
    {
        var uriBuilder = new UriBuilder(url) { Path = path };

        if (request is not null)
        {
            var query = string.Empty;

            foreach (var (key, value) in request.GetQueryParameters())
            {
                query += $"{key}={HttpUtility.UrlEncode(value)}&";
            }
            
            // Remove trailing '&'
            if (query.Length > 0)
            {
                query = query[..^1];
            }

            uriBuilder.Query = query.TrimEnd('&');
        }

        using var response = await _httpClient.GetAsync(uriBuilder.Uri, cancellationToken);
        Throw.IfNotSuccessStatusCode(response, typeof(T));

        var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        Throw.IfDeserializedResponseIsNull(result, uriBuilder.ToString());

        return result;
    }

    public void Dispose()
    {
        if (disposeHttpClient)
        {
            _httpClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}