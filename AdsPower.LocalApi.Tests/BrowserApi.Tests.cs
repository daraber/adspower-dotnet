﻿using AdsPower.LocalApi.Browser;
using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests;

[TestFixture]
[TestOf(typeof(BrowserApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class BrowserApiTests : ApiTestBase
{
    [Test]
    public async Task Start_Success()
    {
        var request = new StartBrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = 0,
            data = new
            {
                ws = new
                {
                    selenium = "127.0.0.1:8080",
                    puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx"
                },
                debug_port = "xxxx",
                webdriver = @"C:\xxxx\chromedriver.exe"
            },
            msg = "success"
        };

        var result = await MockResponse<StartBrowserRequest, StartBrowserResponse>(
            "api/v1/browser/start",
            apiClient => apiClient.Browser.StartAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));

            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data?.DebugPort, Is.EqualTo(response.data.debug_port));
            Assert.That(result.Data?.WebDriver, Is.EqualTo(response.data.webdriver));

            Assert.That(result.Data?.Websockets, Is.Not.Null
                .And.Count.EqualTo(2)
                .And.ContainKey("selenium")
                .And.ContainKey("puppeteer")
            );
        });
    }

    [Test]
    public async Task Start_Failed()
    {
        var request = new StartBrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        var result = await MockResponse<StartBrowserRequest, StartBrowserResponse>(
            "api/v1/browser/start",
            apiClient => apiClient.Browser.StartAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Data, Is.Null);
            Assert.That(result.Message, Is.EqualTo(response.msg));
        });
    }

    [Test]
    public void Start_Canceled()
    {
        var request = new StartBrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        TestCancellationToken<StartBrowserRequest, StartBrowserResponse>(
            "api/v1/browser/start",
            apiClient => apiClient.Browser.StartAsync,
            request,
            response
        );
    }
}