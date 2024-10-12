using AdsPower.LocalApi.Browser;
using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests.Browser;

[TestFixture]
[TestOf(typeof(BrowserApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class BrowserApiTests : ApiTestBase
{
    #region StartAsync

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

    #endregion

    #region StopAsync

    [Test]
    public async Task Stop_Success()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = 0,
            data = new { },
            msg = "success"
        };

        var result = await MockResponse<BrowserRequest, LocalApiResponse>(
            "/api/v1/browser/stop",
            apiClient => apiClient.Browser.StopAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
        });
    }

    [Test]
    public async Task Stop_Failed()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        var result = await MockResponse<BrowserRequest, LocalApiResponse>(
            "/api/v1/browser/stop",
            apiClient => apiClient.Browser.StopAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
        });
    }

    [Test]
    public void Stop_Canceled()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        TestCancellationToken<BrowserRequest, LocalApiResponse>(
            "/api/v1/browser/stop",
            apiClient => apiClient.Browser.StopAsync,
            request,
            response
        );
    }

    #endregion

    #region GetStatusAsync

    [Test]
    public async Task GetStatus_Success()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = 0,
            data = new
            {
                status = "Active",
                ws = new
                {
                    selenium = "127.0.0.1:xxxx",
                    puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx"
                }
            },
            msg = "success"
        };

        var result = await MockResponse<BrowserRequest, BrowserStatusResponse>(
            "/api/v1/browser/active",
            apiClient => apiClient.Browser.GetStatusAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
            Assert.That(result.Data, Is.Not.Null);
            Assert.That(result.Data?.Status, Is.EqualTo(response.data.status));
            Assert.That(result.Data?.Websockets?["selenium"], Is.EqualTo(response.data.ws.selenium));
            Assert.That(result.Data?.Websockets?["puppeteer"], Is.EqualTo(response.data.ws.puppeteer));
        });
    }

    [Test]
    public async Task GetStatus_Failed()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        var result = await MockResponse<BrowserRequest, BrowserStatusResponse>(
            "/api/v1/browser/active",
            apiClient => apiClient.Browser.GetStatusAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
            Assert.That(result.Data, Is.Null);
        });
    }

    [Test]
    public void GetStatus_Canceled()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        TestCancellationToken<BrowserRequest, BrowserStatusResponse>(
            "/api/v1/browser/active",
            apiClient => apiClient.Browser.GetStatusAsync,
            request,
            response
        );
    }

    #endregion

    #region GetStatusListAsync

    [Test]
    public async Task GetStatusList_Success()
    {
        var response = new
        {
            code = 0,
            msg = "success",
            data = new
            {
                list = new[]
                {
                    new
                    {
                        user_id = "xxx",
                        ws = new
                        {
                            puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx",
                            selenium = "127.0.0.1:xxxx"
                        },
                        debug_port = "xxxx",
                        webdriver = "xxxx"
                    }
                }
            }
        };

        var result = await MockResponse<BrowserStatusListResponse>(
            "/api/v1/browser/local-active",
            apiClient => apiClient.Browser.GetStatusListAsync,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));

            Assert.That(result.Data, Is.Not.Null);
        });

        Assert.That(result.Data?.Browsers, Is.Not.Null);
        Assert.That(result.Data?.Browsers.Count, Is.EqualTo(response.data.list.Length));

        var browser = result.Data?.Browsers[0];
        var expectedBrowser = response.data.list[0];

        Assert.Multiple(() =>
        {
            Assert.That(browser?.UserId, Is.EqualTo(expectedBrowser.user_id));
            Assert.That(browser?.Websockets?["puppeteer"], Is.EqualTo(expectedBrowser.ws.puppeteer));
            Assert.That(browser?.Websockets?["selenium"], Is.EqualTo(expectedBrowser.ws.selenium));
            Assert.That(browser?.DebugPort, Is.EqualTo(expectedBrowser.debug_port));
            Assert.That(browser?.WebDriver, Is.EqualTo(expectedBrowser.webdriver));
        });
    }

    [Test]
    public async Task GetStatusList_Failed()
    {
        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        var result = await MockResponse<BrowserStatusListResponse>(
            "/api/v1/browser/local-active",
            apiClient => apiClient.Browser.GetStatusListAsync,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));
            Assert.That(result.Data, Is.Null);
        });
    }

    [Test]
    public void GetStatusList_Canceled()
    {
        var response = new
        {
            code = -1,
            data = new { },
            msg = "failed"
        };

        TestCancellationToken<BrowserStatusListResponse>(
            "/api/v1/browser/local-active",
            apiClient => apiClient.Browser.GetStatusListAsync,
            response
        );
    }

    #endregion
}