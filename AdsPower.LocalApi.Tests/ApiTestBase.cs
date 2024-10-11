using System.Text.Json;
using RichardSzalay.MockHttp;

namespace AdsPower.LocalApi.Tests;

public abstract class ApiTestBase
{
    private const string Url = "http://localhost";
    
    
    protected async Task<TResponse> MockResponse<TRequest, TResponse>(
        string endpoint,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request,
        object responseContent,
        CancellationToken cancellationToken = default
    )
    {
        using var mockApiClient = CreateMockClient(endpoint, responseContent);
        var apiFunction = call(mockApiClient);

        var apiResponse = await apiFunction(request, cancellationToken);
        return apiResponse;
    }
    
    protected void TestCancellationToken<TRequest, TResponse>(
        string endpoint,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request,
        object responseContent
    )
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
        {
            await MockResponse(endpoint, call, request, responseContent, cancellationTokenSource.Token);
        });
    }
    
    private LocalApiClient CreateMockClient(string endpoint, object content)
    {
        var contentString = JsonSerializer.Serialize(content);

        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When($"{Url}/{endpoint}")
            .Respond("application/json", contentString);

        return new LocalApiClient(Url, mockHttp);
    }
}