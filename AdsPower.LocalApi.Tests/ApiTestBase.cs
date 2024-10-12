﻿using System.Text.Json;
using AdsPower.LocalApi.Shared;
using RichardSzalay.MockHttp;

namespace AdsPower.LocalApi.Tests;

public abstract class ApiTestBase
{
    private const string Url = "http://localhost";

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

    protected async Task<TResponse> MockSuccessResponse<TRequest, TResponse>(
        string path,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request,
        object data,
        CancellationToken cancellationToken = default
    ) where TResponse : LocalApiResponse
    {
        var response = new
        {
            code = 0,
            data,
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

        if (result is LocalApiResponse<object> localApiResponse)
        {
            Assert.That(localApiResponse.Data, Is.Not.Null);
        }

        return result;
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

    protected async Task<TResponse> MockResponse<TRequest, TResponse>(
        string path,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request,
        object responseContent,
        CancellationToken cancellationToken = default
    )
    {
        using var mockApiClient = CreateMockClient(path, responseContent);
        var apiFunction = call(mockApiClient);

        var apiResponse = await apiFunction(request, cancellationToken);
        return apiResponse;
    }

    protected void TestCancellationToken<TRequest, TResponse>(
        string path,
        Func<LocalApiClient, Func<TRequest, CancellationToken, Task<TResponse>>> call,
        TRequest request
    )
    {
        using var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();

        var response = new { };

        Assert.ThrowsAsync<TaskCanceledException>(async () =>
        {
            await MockResponse(path, call, request, response, cancellationTokenSource.Token);
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