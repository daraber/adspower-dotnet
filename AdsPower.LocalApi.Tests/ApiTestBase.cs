using System.Text.Json;
using AdsPower.LocalApi.Shared;
using RichardSzalay.MockHttp;

namespace AdsPower.LocalApi.Tests;

public abstract class ApiTestBase
{
    private const string Url = "http://localhost";

    protected async Task MockSuccessResponse<TRequest, TResponse>(
        string path,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request,
        CancellationToken cancellationToken = default
    ) where TResponse : LocalApiResponse
    {
        var response = new
        {
            code = 0,
            data = new { },
            msg = "success"
        };

        using var mockApiClient = CreateMockClient(path, response);
        var apiFunction = call(mockApiClient);

        var result = await apiFunction(request, cancellationToken);

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
        });
    }

    protected async Task<TData> MockSuccessResponse<TRequest, TResponse, TData>(
        string path,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request,
        object data,
        CancellationToken cancellationToken = default
    ) where TData : class where TResponse : LocalApiResponse<TData>
    {
        var response = new
        {
            code = 0,
            msg = "success",
            data
        };

        using var mockApiClient = CreateMockClient(path, response);
        var apiFunction = call(mockApiClient);

        var result = await apiFunction(request, cancellationToken);

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
            Assert.That(result.Data, Is.Not.Null);
        });

        return result.Data!;
    }

    protected async Task MockFailedResponse<TRequest, TResponse>(
        string path,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request,
        CancellationToken cancellationToken = default
    ) where TResponse : LocalApiResponse
    {
        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        using var mockApiClient = CreateMockClient(path, response);
        var apiFunction = call(mockApiClient);

        var result = await apiFunction(request, cancellationToken);

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
        });

        if (result is LocalApiResponse<object> localApiResponse)
        {
            Assert.That(localApiResponse.Data, Is.Null);
        }
    }


    protected async Task<TResponse> MockResponse<TResponse>(
        string path,
        Func<LocalApiClient, Func<CancellationToken, Task<TResponse>>> call,
        object responseContent,
        CancellationToken cancellationToken = default
    )
    {
        using var mockApiClient = CreateMockClient(path, responseContent);
        var apiFunction = call(mockApiClient);

        var apiResponse = await apiFunction(cancellationToken);
        return apiResponse;
    }
    

    protected void TestCancellationToken<TRequest, TResponse>(
        string path,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request
    )
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        var cancellationToken = cancellationTokenSource.Token;
        
        cancellationTokenSource.Cancel();
        

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
        {
            using var mockApiClient = CreateMockClient(path, response);
            var apiFunction = call(mockApiClient);

            _ = await apiFunction(request, cancellationToken);
        });
    }

    private LocalApiClient CreateMockClient(string path, object content)
    {
        var contentString = JsonSerializer.Serialize(content);

        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When($"{Url}{path}")
            .Respond("application/json", contentString);

        return new LocalApiClient(Url, mockHttp);
    }
}