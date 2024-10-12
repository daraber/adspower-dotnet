using AdsPower.LocalApi.Browser;
using AdsPower.LocalApi.Browser.Models;
using AdsPower.LocalApi.Browser.Requests;
using AdsPower.LocalApi.Browser.Responses;
using AdsPower.LocalApi.Shared;
using AdsPower.LocalApi.Tests.Internal;

namespace AdsPower.LocalApi.Tests.Browser;

[TestFixture]
[TestOf(typeof(BrowserApi))]
[Parallelizable(ParallelScope.All)]
[MockTest]
public class BrowserApiMockTests : ApiTestBase
{
    #region StartAsync

    [Test]
    public async Task Start_Success()
    {
        var request = new StartBrowserRequest { UserId = Guid.NewGuid().ToString() };

        var responseData = new
        {
            ws = new
            {
                selenium = "127.0.0.1:8080",
                puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx"
            },
            debug_port = "xxxx",
            webdriver = @"C:\xxxx\chromedriver.exe"
        };

        var resultData = await MockSuccessResponse<StartBrowserRequest, StartBrowserResponse, BrowserData>(
            "/api/v1/browser/start",
            apiClient => apiClient.Browser.StartAsync,
            request,
            responseData
        );

        Assert.Multiple(() =>
        {
            Assert.That(resultData.Websockets, Is.Not.Null);
            Assert.That(resultData.Websockets?["selenium"], Is.EqualTo(responseData.ws.selenium));
            Assert.That(resultData.Websockets?["puppeteer"], Is.EqualTo(responseData.ws.puppeteer));
            Assert.That(resultData.DebugPort, Is.EqualTo(responseData.debug_port));
            Assert.That(resultData.WebDriver, Is.EqualTo(responseData.webdriver));
        });
    }

    [Test]
    public async Task Start_Failed()
    {
        await MockFailedResponse<StartBrowserRequest, StartBrowserResponse>(
            "/api/v1/browser/start",
            apiClient => apiClient.Browser.StartAsync,
            new StartBrowserRequest { UserId = Guid.NewGuid().ToString() }
        );
    }

    [Test]
    public void Start_Canceled()
    {
        TestCancellationToken<StartBrowserRequest, StartBrowserResponse>(
            "api/v1/browser/start",
            apiClient => apiClient.Browser.StartAsync,
            new StartBrowserRequest { UserId = Guid.NewGuid().ToString() }
        );
    }

    #endregion

    #region StopAsync

    [Test]
    public async Task Stop_Success()
    {
        await MockSuccessResponse<BrowserRequest, LocalApiResponse>(
            "/api/v1/browser/stop",
            apiClient => apiClient.Browser.StopAsync,
            new BrowserRequest { UserId = Guid.NewGuid().ToString() }
        );
    }

    [Test]
    public async Task Stop_Failed()
    {
        await MockFailedResponse<BrowserRequest, LocalApiResponse>(
            "/api/v1/browser/stop",
            apiClient => apiClient.Browser.StopAsync,
            new BrowserRequest { UserId = Guid.NewGuid().ToString() }
        );
    }

    [Test]
    public void Stop_Canceled()
    {
        TestCancellationToken<BrowserRequest, LocalApiResponse>(
            "/api/v1/browser/stop",
            apiClient => apiClient.Browser.StopAsync,
            new BrowserRequest { UserId = Guid.NewGuid().ToString() }
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
            status = "Active",
            ws = new
            {
                selenium = "127.0.0.1:xxxx",
                puppeteer = "ws://127.0.0.1:xxxx/devtools/browser/xxxxxx"
            }
        };

        var resultData = await MockSuccessResponse<BrowserRequest, BrowserStatusResponse, BrowserStatus>(
            "/api/v1/browser/active",
            apiClient => apiClient.Browser.GetStatusAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(resultData.Status, Is.EqualTo(response.status));
            Assert.That(resultData.Websockets, Is.Not.Null);
            Assert.That(resultData.Websockets?["selenium"], Is.EqualTo(response.ws.selenium));
            Assert.That(resultData.Websockets?["puppeteer"], Is.EqualTo(response.ws.puppeteer));
        });
    }

    [Test]
    public async Task GetStatus_Failed()
    {
        await MockFailedResponse<BrowserRequest, BrowserStatusResponse>(
            "/api/v1/browser/active",
            apiClient => apiClient.Browser.GetStatusAsync,
            new BrowserRequest { UserId = Guid.NewGuid().ToString() }
        );
    }

    [Test]
    public void GetStatus_Canceled()
    {
        TestCancellationToken<BrowserRequest, BrowserStatusResponse>(
            "/api/v1/browser/active",
            apiClient => apiClient.Browser.GetStatusAsync,
            new BrowserRequest { UserId = Guid.NewGuid().ToString() }
        );
    }

    #endregion

    #region GetStatusListAsync

    [Test]
    public async Task GetStatusList_Success()
    {
        var request = new BrowserRequest { UserId = Guid.NewGuid().ToString() };

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

        var result = await MockResponse<BrowserRequest, BrowserStatusListResponse>(
            "/api/v1/browser/local-active",
            apiClient => apiClient.Browser.GetStatusListAsync,
            request,
            response
        );

        Assert.Multiple(() =>
        {
            Assert.That(result.Code, Is.EqualTo(response.code));
            Assert.That(result.Message, Is.EqualTo(response.msg));

            Assert.That(result.Data, Is.Not.Null);
        });

        Assert.That(result.Data?.List, Is.Not.Null);
        Assert.That(result.Data?.List.Count, Is.EqualTo(response.data.list.Length));

        var browser = result.Data?.List[0];
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
        await MockFailedResponse<BrowserRequest, BrowserStatusListResponse>(
            "/api/v1/browser/local-active",
            apiClient => apiClient.Browser.GetStatusListAsync,
            new BrowserRequest { UserId = Guid.NewGuid().ToString() }
        );
    }

    [Test]
    public void GetStatusList_Canceled()
    {
        TestCancellationToken<BrowserRequest, BrowserStatusListResponse>(
            "/api/v1/browser/local-active",
            apiClient => apiClient.Browser.GetStatusListAsync,
            new BrowserRequest { UserId = Guid.NewGuid().ToString() }
        );
    }

    #endregion
}