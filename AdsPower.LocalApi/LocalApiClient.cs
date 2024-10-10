using System.Net.Http.Json;
using System.Web;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi;

public class LocalApiClient(string url, HttpClient? httpClient) : ILocalApiClient
{
    private readonly HttpClient _httpClient = httpClient ?? new HttpClient();

    public IBrowserApi Browser => new BrowserApi(this);

    public async Task<StatusResponse> GetConnectionStatus(CancellationToken cancellationToken = default)
    {
        return await GetAsync<StatusResponse>("status", cancellationToken);
    }

    internal async Task<T> GetAsync<T>(
        string endpoint,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await _httpClient.GetAsync($"{url}/{endpoint}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var message =
                $"Bad HTTP response from {endpoint} for type {typeof(T).Name}: {response.StatusCode} {response.ReasonPhrase}";

            throw new HttpRequestException(message);
        }

        var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        if (result is null)
        {
            var message = $"Deserialized HTTP response from {endpoint} of type {typeof(T).Name} is null";
            throw new HttpRequestException(message);
        }

        return result;
    }
}