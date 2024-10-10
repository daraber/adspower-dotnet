using System.Net.Http.Json;
using AdsPower.LocalApi.Responses;

namespace AdsPower.LocalApi;

public class LocalApiClient(string url, HttpClient? httpClient) : ILocalApiClient
{
    private readonly HttpClient _httpClient = httpClient ?? new HttpClient();
    
    public IBrowserApi Browser => new BrowserApi(this);
    
    public async Task<StatusResponse> GetStatusAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<StatusResponse>("status", cancellationToken);
        
    }
    
    internal async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"{url}/{endpoint}", cancellationToken);
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<T>(cancellationToken);
        if (result is null)
        {
            throw new HttpRequestException($"Response of type {typeof(T)} is null");
        }
        
        return result;
    }
}